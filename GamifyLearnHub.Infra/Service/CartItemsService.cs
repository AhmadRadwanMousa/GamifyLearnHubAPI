using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Service
{
    public class CartItemsService : ICartItemsService
    {
        private readonly ICartItemsRepository _cartItemsRepository;
        public CartItemsService(ICartItemsRepository cartItemsRepository)
        {
            _cartItemsRepository=cartItemsRepository;
        }
        public async Task<int> CreateCartItems(Cartitem cartitem)
        {
          return await  _cartItemsRepository.CreateCartItems(cartitem); 
        }

        public async Task<int> DeleteCartItems(int cartItemId)
        {
            return await _cartItemsRepository.DeleteCartItems(cartItemId);  
        }

        public async Task<List<Cartitem>> GetAllCartItems()
        {
            return await _cartItemsRepository.GetAllCartItems();
        }

        public async Task<int> UpdateCartItems(Cartitem cartitem)
        {
            return await _cartItemsRepository.UpdateCartItems(cartitem);
        }
    }
}
