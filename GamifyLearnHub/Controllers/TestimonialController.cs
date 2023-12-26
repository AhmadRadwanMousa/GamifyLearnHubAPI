using GamifyLearnHub.Attributes;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Service;
using GamifyLearnHub.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }


        [HttpGet]
        //[CheckClaims("roleId", "1")]
        public async Task<List<Testimonial>> GetAllTestimonials()
        {
            return await _testimonialService.GetAllTestimonials();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        //[CheckClaims("roleId", "1")]
        public async Task<Testimonial> GetTestimonialById(int id)
        {
            return await _testimonialService.GetTestimonialById(id);
        }



        [HttpPost]
        //[CheckClaims("roleId", "3")]
        public async Task<IActionResult> CreateTestimonial([FromForm] Testimonial testimonial)
        {
            var createdId = await _testimonialService.CreateTestimonial(testimonial);
            if (createdId != null)
            {
                return Ok(new { CreatedId = createdId });

            }
            else { return BadRequest("Create failed."); }
        }


        [HttpGet]
        [Route("AcceptTestimonial/{id}")]
        //[CheckClaims("roleId", "1")]
        public async Task<IActionResult> AcceptTestimonial(int id)
        {
            var rowsAffected = await _testimonialService.AcceptTestimonial(id);

            if (rowsAffected > 0)
            {
                return Ok(new { RowsAffected = rowsAffected });
            }
            else
            {
                return BadRequest("Accepted failed.");
            }

        }



        [HttpGet]
        [Route("RejectTestimonial/{id}")]
        //[CheckClaims("roleId", "1")]
        public async Task<IActionResult> RejectTestimonial(int id)
        {
            var rowsAffected = await _testimonialService.RejectTestimonial(id);

            if (rowsAffected > 0)
            {
                return Ok(new { RowsAffected = rowsAffected });
            }
            else
            {
                return BadRequest("Rejected failed.");
            }

        }





        //[HttpPut]
        //public async Task<IActionResult> UpdateTestimonial([FromForm] Testimonial testimonial)

        //{
        //    var rowsAffected = await _testimonialService.UpdateTestimonial(testimonial);

        //    if (rowsAffected > 0)
        //    {
        //        return Ok(new { RowsAffected = rowsAffected });
        //    }
        //    else
        //    {
        //        return BadRequest("Update failed. Role not found or no changes made.");
        //    }
        //}



        [HttpDelete("{id}")]
        //[CheckClaims("roleId", "1")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var rowsAffected = await _testimonialService.DeleteTestimonial(id);

            if (rowsAffected > 0)
            {
                return Ok(new { RowsAffected = rowsAffected });
            }
            else
            {
                return BadRequest("Delete failed. Testimonial not found or some thing wrong.");
            }

        }
    }
}
