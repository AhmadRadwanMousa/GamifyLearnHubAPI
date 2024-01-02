using Dapper;
using GamifyLearnHub.Core.Common;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Repository;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Repositroy
{
    public class CartItemsRepository : ICartItemsRepository
    {
        private readonly IDbContext _dbContext;
        public CartItemsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddCartItem(int userId, int programId, int sectionId)
        {
            var p = new DynamicParameters();
            p.Add("user_id", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("program_id", programId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("section_id", sectionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("new_cartItemId", userId, dbType: DbType.Int32, direction: ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("CartItems_Package.AddCartItem", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("new_cartItemId");
        }

        public async Task<int> CreateCartItems(Cartitem cartitem)
        {

            var p = new DynamicParameters();
            p.Add("cart_id", cartitem.Cartid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("program_id", cartitem.Programid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("created_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("section_id", cartitem.Sectionid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("CartItems_Package.CreateCartItem", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("created_id");

        }

        public async Task<int> DeleteCartItems(int cartItemId, int cartItemPrice)
        {
            var p = new DynamicParameters();
            p.Add("id", cartItemId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("cartItemPrice", cartItemPrice, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("CartItems_Package.DeleteCartItem", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("RowsAffected");

        }

        public async Task<List<Cartitem>> GetAllCartItems()
        {
            var result = await _dbContext.Connection.QueryAsync<Cartitem>("CartItems_Package.GetAllCartItems", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<Cartitem>> GetCartItemsByUserId(int userId)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("user_id", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = await _dbContext.Connection.QueryAsync<Cartitem, Program, Cartitem>
                    ("CartItems_Package.GetCartItemsByUserId", (cartItem, program) =>
                    {
                        cartItem.Program = program;
                        return cartItem;
                    }, p, splitOn: "programId", commandType: CommandType.StoredProcedure);
                var cartItems = result.ToList();
                if (cartItems.Count == 0)
                {
                    return new List<Cartitem>();
                }
                return cartItems;
            }
            catch (OracleException ex) when (ex.Number == 1403) 
            {

                return new List<Cartitem>();
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"OracleException: {ex.Message}");
                throw;
            }

        }

        public async Task<int> UpdateCartItems(Cartitem cartitem)
        {
            var p = new DynamicParameters();
            p.Add("id", cartitem.Cartitemsid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("cart_id", cartitem.Cartid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("program_id", cartitem.Programid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("CartItems_Package.UpdateCartItem", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("RowsAffected");
        }
    }
}
