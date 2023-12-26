using GamifyLearnHub.Attributes;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentSolutionController : ControllerBase
    {
        private readonly IAssignmentSolutionService _assignmentSolutionService;
        public AssignmentSolutionController(IAssignmentSolutionService assignmentSolutionService)
        {
            _assignmentSolutionService= assignmentSolutionService;
        }
        [HttpGet("{assignmentId}")]
        //[CheckClaims("roleId","2")]
        public async Task<List<Assignmentsolution>> GetAssignmentSolutionByAssignmentId(int assignmentId)
        {
            return await _assignmentSolutionService.GetAssignmentSolutionByAssignmentId(assignmentId);
        }
        [HttpPost]
        //[CheckClaims("roleId", "3")]
        public async Task<int> CreateAssignmentSolution([FromForm]Assignmentsolution assignmentsolution)
        {
          return await _assignmentSolutionService.CreateAssignmentSolution(assignmentsolution);    
        }
        [HttpPut]
        //[CheckClaims("roleId", "3")]

        public async Task<int> UpdateAssignmentSolution([FromForm] Assignmentsolution assignmentsolution)
        {
            return await _assignmentSolutionService.UpdateAssignmentSolution(assignmentsolution);
        }
        [HttpDelete("{assignmentSolutionId}")]
        [Authorize]
        public async Task<int> DeleteAssignmentSolution(int assignmentSolutionId)
        {
            return await _assignmentSolutionService.DeleteAssignmentSolution(assignmentSolutionId);
        }
        [HttpPut]
        [CheckClaims("roleId","2")]
        [Route("UpdateAssignmentSolutionMark")]

        public async Task<int> UpdateAssignmentSolutionMark(AssignmentMark mark)
        {
            return await _assignmentSolutionService.UpdateAssignmentSolutionMark(mark);
        }



    }

}
