using GamifyLearnHub.Attributes;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Service;
using GamifyLearnHub.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamLearnerController : ControllerBase
    {

        private readonly IExamLearnerService _examLearnerService;
        public ExamLearnerController(IExamLearnerService examLearnerService)
        {
            _examLearnerService = examLearnerService;
        }




        [HttpGet]
        [Route("GetExamDetails/{id}")]
        public async Task<List<ExamLearner>> GetExamDetails(int id)
        {
            return await _examLearnerService.GetExamDetails(id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExamSolution(List<Examsolution> examsolutions)
        {
            var result = _examLearnerService.CreateExamSolution(examsolutions);
            if (result != null)
            {
                return Ok();

            }
            else { return BadRequest("Submit failed."); }
        }


        [HttpGet]
        [Route("GetUserSolution/{examId}/{userId}")]
        public async Task<List<SolutionUserDetails>> GetSolutionUserDetails(int examId , int userId)
        {
            return await _examLearnerService.GetSolutionUserDetails(examId , userId);
        }


        [HttpGet]
        [Route("GetExamsToday/{sectionId}")]
        [CheckClaims("roleId", "3")]
        public async Task<List<Exam>> GetExamsToday( int sectionId)
        {
            return await _examLearnerService.GetExamsToday(sectionId);
        }

        [HttpGet]
        [Route("GetAllSectionsByLearnerId/{userId}")]
        //[CheckClaims("roleId", "3")]
        public async Task<List<Section>> GetAllSectionsByLearnerId(int userId)
        {
            return await _examLearnerService.GetAllSectionsByLearnerId(userId);
        }


        [HttpGet]
        [Route("GetAllExamByUserSection/{userId}/{sectionId}")]
        //[CheckClaims("roleId", "3")]
        public async Task<List<Exam>> GetAllExamByUserSection(int userId , int sectionId)
        {
            return await _examLearnerService.GetAllExamByUserSection(userId , sectionId);
        }

    }
}
