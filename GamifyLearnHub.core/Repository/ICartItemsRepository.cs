using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
    public interface ICartItemsRepository
    {
        Task<int> CreateCartItems(Cartitem cartitem);
        Task<int> DeleteCartItems(int cartItemId, int cartItemPrice);
        Task<List<Cartitem>> GetAllCartItems();
        Task<int> UpdateCartItems(Cartitem cartitem);
        Task<List<Cartitem>>GetCartItemsByUserId(int userId);   
        Task<int>AddCartItem(int userId,int programId,int sectionId);

    }
}
