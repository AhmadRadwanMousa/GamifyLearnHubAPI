using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
	public interface IPlanRepository
	{
		Task<List<Plan>> GetAllPlans();
		void CreatePlan(Plan plan);
		void DeletePlan(int id);
		public void UpdatePlan(Plan plan);
		Task<Plan> GetPlanById(int id);

	}
}
