using GamifyLearnHub.Attributes;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlanController : ControllerBase
	{
		private readonly IPlanService _planService;
	

        public PlanController(IPlanService planService)
        {
			this._planService = planService;
			
        }
		[HttpGet]
		[Route("GetAllPlans")]

		public async Task<List<Plan>> GetAllPlans()
		{
			return await _planService.GetAllPlans();
		}

        [HttpGet]
        [Route("GetAllPlansWithPrograms")]
        public async Task<List<Plan>> GetAllPlansWithPrograms()
        {
            return await _planService.GetAllPlansWithPrograms();
        }

        [HttpPost]
		[Route("CreatePlan")]
        [CheckClaims("roleId", "1")]
        public async Task<int> CreatePlan([FromBody] Plan plan)
		{
			return await _planService.CreatePlan(plan);
		}
		[HttpPut]
		[Route("UpdatePlan")]
        [CheckClaims("roleId", "1")]
        public async Task<int> UpdatePlan([FromBody] Plan plan)
		{
			return await _planService.UpdatePlan(plan);
		}
		[HttpDelete("{id}")]
        [CheckClaims("roleId", "1")]
        public async Task<int> DeletePlan(int id)
		{
			return await _planService.DeletePlan(id);
		}
		[HttpGet]
		[Route("GetPlanById/{id}")]
		public async Task<Plan> GetPlanById(int id)
		{
			return await _planService.GetPlanById(id);
		}
		
	}
}
