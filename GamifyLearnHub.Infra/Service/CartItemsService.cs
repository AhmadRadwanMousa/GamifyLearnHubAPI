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

        public async Task<int> AddCartItem(int userId, int programId)
        {
           return await _cartItemsRepository.AddCartItem(userId, programId);
        }

        public async Task<int> CreateCartItems(Cartitem cartitem)
        {
          return await  _cartItemsRepository.CreateCartItems(cartitem); 
        }

        public async Task<int> DeleteCartItems(int cartItemId, int cartItemPrice)
        {
            return await _cartItemsRepository.DeleteCartItems(cartItemId, cartItemPrice);  
        }

        public async Task<List<Cartitem>> GetAllCartItems()
        {
            return await _cartItemsRepository.GetAllCartItems();
        }

        public async Task<List<Cartitem>> GetCartItemsByUserId(int userId)
        {
            return await _cartItemsRepository.GetCartItemsByUserId(userId);
        }

        public async Task<int> UpdateCartItems(Cartitem cartitem)
        {
            return await _cartItemsRepository.UpdateCartItems(cartitem);
        }
    }
}
