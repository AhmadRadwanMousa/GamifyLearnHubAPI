using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TakeAttendenceBySectionController : ControllerBase
    {
        private readonly IAttendenceDetailService _attendenceDetailService;
        private readonly IAttendenceService _attendenceService;
        private readonly ISectionService _sectionService;

        public TakeAttendenceBySectionController(IAttendenceDetailService attendenceDetailService, IAttendenceService attendenceService, ISectionService sectionService )
        {
            _attendenceDetailService = attendenceDetailService; 
            _attendenceService = attendenceService;
            _sectionService = sectionService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateAttendenceForSection(AttendenceWithDetails attendenceWithDetails) 
        {
           
            int? attendenceId = await _attendenceService.CreateAttendence(attendenceWithDetails.attendence);

            if (attendenceId != null)
            {
                foreach (var detail in attendenceWithDetails.attendencedetail)
                {
                    detail.Attendenceid = attendenceId;
                    await _attendenceDetailService.CreateAttendenceDetails(detail);
                }
                return Ok("Submit successfully.");
            }
            else 
            {
                return BadRequest("Submit Failed.");
            }

        }

        [HttpGet("GetAttendenceBySection/{id}")]
        public async Task<IActionResult> GetAttendenceBySection(int id)
        {

            var AllAttendences = await _attendenceService.GetAllAttendence();
            var AllAttendencesDetails = await _attendenceDetailService.GetAllAttendenceDetails();
            var Attendences = AllAttendences.Where(a => a.Sectionid == id).ToList();
            foreach (var at in Attendences)
            {
                at.Attendencedetails = AllAttendencesDetails.Where(a => a.Attendenceid == at.Attendenceid).ToList();
            }


            return Ok(Attendences);
        }

        [HttpGet("GetSectionsByInstructor/{id}")]
        public async Task<IActionResult> GetSectionsByInstructor(int id) 
        { 
            var sections = await _sectionService.GetAllSections();
            if (sections == null) return NotFound("Sections is empty.");

            var InstructorSections = sections.Where(s=> s.Userid == id).ToList();
            if (InstructorSections == null) return NotFound("Sections is empty");

            return Ok(InstructorSections);
        }


    }
}
