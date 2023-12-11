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
    public class CartService:ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<int> CreateCart(Cart cart)
        {
          return  await _cartRepository.CreateCart(cart);
        }

        public async Task<int> DeleteCart(int cartId)
        {
           return await _cartRepository.DeleteCart(cartId); 
        }

        public async Task<List<Cart>> GetAllCarts()
        {
            return await _cartRepository.GetAllCarts(); 
        }

        public async Task<Cart> GetCartById(int cartId)
        {
            return await _cartRepository.GetCartById(cartId);   
        }

        public async Task<int> UpdateCart(Cart cart)
        {
            return await _cartRepository.UpdateCart(cart);  
        }
    }
}
