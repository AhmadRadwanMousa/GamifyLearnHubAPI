﻿using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemsService _cartItemsService;
        public CartItemsController(ICartItemsService cartItemsService)
        {

            _cartItemsService = cartItemsService;
        }
        [HttpGet("{userId}")]

        public async Task<List<Cartitem>> GetCartItemsByUserId( int userId)
        {
            return await _cartItemsService.GetCartItemsByUserId(userId);
        }
        [HttpPost]

       public async Task<int> AddCartItem([FromForm]int userId, [FromForm]int programId)
        {
            return await _cartItemsService.AddCartItem(userId,programId);
        }
        [HttpDelete("{cartItemId}/{cartItemPrice}")]
        public async Task<int> DeleteCartItems(int cartItemId,int cartItemPrice)
        {
            return await _cartItemsService.DeleteCartItems(cartItemId, cartItemPrice);
        }
       
       
    }
}
