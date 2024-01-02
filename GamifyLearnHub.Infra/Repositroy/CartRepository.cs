using Dapper;
using GamifyLearnHub.Core.Common;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Repositroy
{
    public class CartRepository : ICartRepository
    {
        private readonly IDbContext _dbContext;
        public CartRepository(IDbContext dbContext)
        {
            _dbContext= dbContext;  
        }
        public async Task<int> CreateCart(Cart cart)
        {
            var p = new DynamicParameters();
            p.Add("User_Id",cart.Userid,dbType:DbType.Int32,direction:ParameterDirection.Input);
            p.Add("Total_Price", cart.Totalprice,dbType:DbType.Int32,direction:ParameterDirection.Input);
            p.Add("Cart_Status", cart.Cartstatus,dbType:DbType.String,direction:ParameterDirection.Input);
            p.Add("Payment_Id", cart.Paymentid,dbType:DbType.Int32,direction:ParameterDirection.Input);
            p.Add("CreatedId",dbType:DbType.Int32,direction:ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("Cart_Package.CreateCart",p,commandType:CommandType.StoredProcedure);
            return p.Get<int>("CreatedId");

        }

        public async Task<int> DeleteCart(int cartId)
        {
            var p = new DynamicParameters();
            p.Add("id",cartId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RowsAffected",  dbType: DbType.Int32, direction: ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("Cart_Package.DeleteCart", p,commandType:CommandType.StoredProcedure);
            return p.Get<int>("RowsAffected");
        }

        public async Task<List<Cartitem>> GetAllCarts(int userId)
        {
            var p = new DynamicParameters();
            p.Add("user_id",userId,dbType:DbType.Int32, direction:ParameterDirection.Input);    
            var result = await _dbContext.Connection.QueryAsync<Cartitem,Program,Plan,Cartitem>
            ("Cart_Package.GetAllCarts", ( cartItems,program,plan) =>
            {
                program.Plan = plan;
               cartItems.Program = program; 
                return cartItems;
            },  p,splitOn:"programId,planId", commandType:CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Cart> GetCartById(int cartId)
        {
            var p = new DynamicParameters();    
            p.Add("id",cartId,dbType:DbType.Int32,direction:ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Cart>("Cart_Package.GetCartById",p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

    

        public async Task<int> UpdateCart(Cart cart)
        {
            var p = new DynamicParameters();
            p.Add("User_Id", cart.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Total_Price", cart.Totalprice, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Cart_Status", cart.Cartstatus, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Payment_Id", cart.Paymentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Cart_Id",cart.Cartid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("Cart_Package.UpdateCart",p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("RowsAffected");
        }
    }
}
