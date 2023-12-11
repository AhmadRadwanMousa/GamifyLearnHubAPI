using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
    public interface ICartItemsService
    {
        Task<int> CreateCartItems(Cartitem cartitem);
        Task<int> DeleteCartItems(int cartItemId);
        Task<List<Cartitem>> GetAllCartItems();
        Task<int> UpdateCartItems(Cartitem cartitem);

    }
}
