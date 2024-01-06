using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginCredentails loginDetails)
        {
            var token = await _authenticationService.Login(loginDetails);
           
            if (token == null) { 
            return Unauthorized();
            }
            return new JsonResult(new { token=token });
        }
    }
}
