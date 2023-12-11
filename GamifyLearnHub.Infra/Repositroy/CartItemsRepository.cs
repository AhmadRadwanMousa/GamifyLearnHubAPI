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
    public class CartItemsRepository:ICartItemsRepository
    {
        private readonly IDbContext _dbContext;
        public CartItemsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<int> CreateCartItems(Cartitem cartitem)
        {

            var p = new DynamicParameters();
            p.Add("cart_id",cartitem.Cartid,dbType:DbType.Int32,direction:ParameterDirection.Input);
            p.Add("program_id", cartitem.Programid,dbType:DbType.Int32,direction:ParameterDirection.Input);
            p.Add("created_id", dbType:DbType.Int32,direction:ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("CartItems_Package.CreateCartItem",p,commandType:CommandType.StoredProcedure);
            return p.Get<int>("created_id");
        
        }

        public async Task<int> DeleteCartItems(int cartItemId)
        {
            var p = new DynamicParameters();
            p.Add("id",cartItemId,dbType:DbType.Int32,direction:ParameterDirection.Input);
            p.Add("RowsAffected", dbType:DbType.Int32,direction:ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("CartItems_Package.DeleteCartItem",p,commandType:CommandType.StoredProcedure);
            return p.Get<int>("RowsAffected");

        }

        public async Task<List<Cartitem>> GetAllCartItems()
        {
            var result = await _dbContext.Connection.QueryAsync<Cartitem>("CartItems_Package.GetAllCartItems", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<int> UpdateCartItems(Cartitem cartitem)
        {
            var p = new DynamicParameters();
            p.Add("id", cartitem.Cartitemsid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("cart_id", cartitem.Cartid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("program_id", cartitem.Programid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RowsAffected",  dbType: DbType.Int32, direction: ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("CartItems_Package.UpdateCartItem",p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("RowsAffected");
        }
    }
}
