using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
	public interface IPlanService
	{
		Task<List<Plan>> GetAllPlans();
		Task<int> CreatePlan(Plan plan);
		Task<int> DeletePlan(int id);
		Task<int> UpdatePlan(Plan plan);
		Task<Plan> GetPlanById(int id);
		Task<List<Plan>> GetAllPlansWithPrograms();


    }
}
