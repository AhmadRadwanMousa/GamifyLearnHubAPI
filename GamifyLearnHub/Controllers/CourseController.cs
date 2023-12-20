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
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }



        [HttpGet]
        //[CheckClaims("roleId", "1")]
        public async Task<List<Course>> GetAllCourses()
        {
            return await _courseService.GetAllCourses();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        //[CheckClaims("roleId", "1")]
        public async Task<Course> GetCourseById(int id)
        {
            return await _courseService.GetCourseById(id);
        }



        [HttpPost]
        //[CheckClaims("roleId", "1")]
        public async Task<IActionResult> CreateCourse([FromForm] Course course)
        {
            var createdId = await _courseService.CreateCourse(course);
            if (createdId != null)
            {
                return Ok(new { CreatedId = createdId });

            }
            else { return BadRequest("Create failed."); }
        }



        [HttpPost]
        [Route("UploadImage")]
        //[CheckClaims("roleId", "1")]
        public Course UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = $"{Guid.NewGuid().ToString()}_{file.FileName}";
            var fullPath = Path.Combine("Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {

                file.CopyTo(stream);
            }
            Course course = new Course();
            course.Courseimage = fileName;
            return course;
        }

        [HttpPut]
        //[CheckClaims("roleId", "1")]
        public async Task<IActionResult> UpdateCourse([FromForm] Course course)

        {
            var rowsAffected = await _courseService.UpdateCourse(course);

            if (rowsAffected > 0)
            {
                return Ok(new { RowsAffected = rowsAffected });
            }
            else
            {
                return BadRequest("Update failed. Role not found or no changes made.");
            }
        }



        [HttpDelete("{id}")]
        //[CheckClaims("roleId", "1")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var rowsAffected = await _courseService.DeleteCourse(id);

            if (rowsAffected > 0)
            {
                return Ok(new {  RowsAffected = rowsAffected });
            }
            else
            {
                return BadRequest("Delete failed. Role not found or some thing wrong.");
            }

        }



    }
}
