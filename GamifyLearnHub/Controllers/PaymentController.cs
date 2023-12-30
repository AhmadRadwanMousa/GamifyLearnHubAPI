using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;            
        }
        [HttpPost]
        public async Task<int> CreatePayment([FromBody]PaymentDetails paymentdetails)
        {
          return  await _paymentService.CreatePayment(paymentdetails);
        }
    }
}
