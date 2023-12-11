using GamifyLearnHub.Attributes;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentSolutionDetailsController : ControllerBase
    {
        private readonly IAssignmentSolutionDetailsService _assignmentSolutionDetailsService;
        public AssignmentSolutionDetailsController(IAssignmentSolutionDetailsService assignmentSolutionDetailsService)
        {
            _assignmentSolutionDetailsService = assignmentSolutionDetailsService;   
        }
        [HttpPost]
        [CheckClaims("roleId", "2")]
        public async Task<int> CreateAssignmentSolutionDetails([FromForm]Assignmentsolutiondetail assignmentsolutiondetail)
        {
            return await _assignmentSolutionDetailsService.CreateAssignmentSolutionDetails(assignmentsolutiondetail);
        }
        [HttpDelete("{assignmentSolutionDetailsId}")]
        [CheckClaims("roleId", "2")]
        public async Task<int> DeleteAssignmentSolutionDetails(int assignmentSolutionDetailsId)
        {
            return await _assignmentSolutionDetailsService.DeleteAssignmentSolutionDetails(assignmentSolutionDetailsId);
        }
        [HttpGet("GetAssignmentSolutionById/{assignmentSolutionDetailsId}")]
        [Authorize]
        
        public async Task<Assignmentsolutiondetail> GetAssignmentsolutiondetailById(int assignmentSolutionDetailsId)
        {
            return await _assignmentSolutionDetailsService.GetAssignmentsolutiondetailById(assignmentSolutionDetailsId);
        }
        [HttpGet("{assignmentId}")]
        [CheckClaims("roleId", "2")]

        public async Task<List<Assignmentsolutiondetail>> GetAssignmentSolutionDetailsByAssignmentId(int assignmentId)
        {
            return await _assignmentSolutionDetailsService.GetAssignmentSolutionDetailsByAssignmentId(assignmentId);
        }   

        [HttpPut]
        [CheckClaims("roleId", "2")]
        public async Task<int> UpdateAssignmentSolutionDetails([FromForm]Assignmentsolutiondetail assignmentsolutiondetail)
        {
            return await _assignmentSolutionDetailsService.UpdateAssignmentSolutionDetails(assignmentsolutiondetail);
        }
    }
}
