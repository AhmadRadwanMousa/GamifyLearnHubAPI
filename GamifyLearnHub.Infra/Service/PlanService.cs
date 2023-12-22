using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Service
{
	public class PlanService : IPlanService
	{
		private readonly IPlanRepository _planRepository;

        public PlanService(IPlanRepository planRepository)
        {
			this._planRepository = planRepository;   
        }
        public async Task<int> CreatePlan(Plan plan)
		{
			return await _planRepository.CreatePlan(plan);
		}

		public async Task<int> DeletePlan(int id)
		{
			return await _planRepository.DeletePlan(id);
		}

		public async Task<List<Plan>> GetAllPlans()
		{
			return await _planRepository.GetAllPlans();	
		}

        public async Task<List<Plan>> GetAllPlansWithPrograms()
        {
            return await _planRepository.GetAllPlansWithPrograms();
        }

        public async Task<Plan> GetPlanById(int id)
		{
			return await _planRepository.GetPlanById(id);
		}

		public async Task<int> UpdatePlan(Plan plan)
		{
			return await _planRepository.UpdatePlan(plan);
		}
	}
}
