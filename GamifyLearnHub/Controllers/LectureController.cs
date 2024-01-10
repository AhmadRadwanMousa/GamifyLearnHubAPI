using GamifyLearnHub.Attributes;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectureController : ControllerBase
    {
        private readonly ILectureService _lectureService;

        public LectureController(ILectureService lectureService)
        {
            _lectureService = lectureService;
        }

        [HttpGet]
        public async Task<IEnumerable<Lecture>> GetAllLectures()
        {
            return await _lectureService.GetAllLectures();
        }

        [HttpGet("{lectureId}")]
        public async Task<Lecture> GetLectureById(decimal lectureId)
        {
            return await _lectureService.GetLectureById(lectureId);
        }

        [HttpPost]
        [CheckClaims("roleId", "2")]
        public async Task<ActionResult<decimal>> CreateLecture(Lecture lecture)
        {
            decimal createdId = await _lectureService.CreateLecture(lecture);
            return CreatedAtAction(nameof(GetLectureById), new { lectureId = createdId }, createdId);
        }

        [HttpPut("{lectureId}")]
        [CheckClaims("roleId", "2")]
        public async Task<IActionResult> UpdateLecture(decimal lectureId, Lecture lecture)
        {
            lecture.Lectureid = lectureId;
            int affectedRows = await _lectureService.UpdateLecture(lecture);

            return affectedRows > 0
                ? Ok(new { affectedRows })
                : NotFound(new { affectedRows });
        }

        [HttpDelete("{lectureId}")]
        [CheckClaims("roleId", "2")]
        public async Task<IActionResult> DeleteLecture(decimal lectureId)
        {
            try
            {
                int affectedRows = await _lectureService.DeleteLecture(lectureId);
                return Ok(new { affectedRows });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
        [HttpGet]
        [Route("GetLecturesCountPerCourse/{userId}/{programId}")]
        [CheckClaims("roleId", "3")]
        public async Task<List<LecturesPerCourse>>GetLecturesCountPerCourse(int userId,int programId)
        {
            return await _lectureService.GetLecturesCountByCourse(userId, programId);   
        }
    }
}
