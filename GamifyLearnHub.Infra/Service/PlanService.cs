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
        public void CreatePlan(Plan plan)
		{
			_planRepository.CreatePlan(plan);
		}

		public void DeletePlan(int id)
		{
			_planRepository.DeletePlan(id);
		}

		public async Task<List<Plan>> GetAllPlans()
		{
			return await _planRepository.GetAllPlans();	
		}

		public async Task<Plan> GetPlanById(int id)
		{
			return await _planRepository.GetPlanById(id);
		}

		public void UpdatePlan(Plan plan)
		{
			_planRepository.UpdatePlan(plan);
		}
	}
}
