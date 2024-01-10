using GamifyLearnHub.Attributes;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService= cartService;  
        }
        [HttpGet("{userId}")]
        [CheckClaims("roleId", "3")]
        public async Task<List<Cartitem>> GetAllCarts(int userId)
        {
            return await _cartService.GetAllCarts(userId);
        }
        [HttpPut]
        [CheckClaims("roleId", "3")]
        public async Task<int>UpdateCartTotal(Cart cart)
        {
            return await _cartService.UpdateCart(cart); 
        }

    }
}
