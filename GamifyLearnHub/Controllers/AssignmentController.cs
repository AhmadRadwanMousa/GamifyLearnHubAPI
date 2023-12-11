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

    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;
        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService; 
        }
        [HttpGet("{sectionId}")]
        [AllowAnonymous]
        public async Task<List<Assignment>>GetAssignmentsBySectionId(int sectionId)
        {
            return await _assignmentService.GetAssignmentBySectionId(sectionId);   
        }
        [HttpPost]
        [CheckClaims("roleId", "2")]
        public async Task<int> CreateAssignment([FromForm]Assignment assignment)
        {
            return await _assignmentService.CreateAssignment(assignment);
        }
        [HttpDelete("{assignmentId}")]
        [CheckClaims("roleId", "2")]
        public async Task<int> DeleteAssignment(int assignmentId)
        {
            return await _assignmentService.DeleteAssignment(assignmentId);
        }
        [HttpPut]
        [CheckClaims("roleId", "2")]
        public async Task<int> UpdateAssignment([FromForm]Assignment assignment)
        {
            return await _assignmentService.UpdateAssignment(assignment);
        }
    }
}
