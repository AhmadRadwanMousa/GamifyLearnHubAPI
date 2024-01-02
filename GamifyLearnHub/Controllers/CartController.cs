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
        public async Task<List<Cartitem>> GetAllCarts(int userId)
        {
            return await _cartService.GetAllCarts(userId);
        }

    }
}
