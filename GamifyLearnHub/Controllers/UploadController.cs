using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UploadController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;   
        }


        [HttpPost]
        [Route("UploadImage")]

        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null)
            {
                return BadRequest("SomethingWentWrong!");
            }

            string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var filePath = Path.Combine("Images/", fileName);
            var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, filePath);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return new JsonResult(new { path = "https://localhost:7036/Images/" + fileName });
        }
    }
}
