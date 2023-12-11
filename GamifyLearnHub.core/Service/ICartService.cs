using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
    public interface ICartService
    {
        Task<int> CreateCart(Cart cart);
        Task<int> UpdateCart(Cart cart);
        Task<int> DeleteCart(int cartId);
        Task<Cart> GetCartById(int cartId);
        Task<List<Cart>> GetAllCarts();
    }
}
