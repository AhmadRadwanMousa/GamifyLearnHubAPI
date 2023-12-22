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
		Task<Plan> GetPlanById(int id);
		Task<int> CreatePlan(Plan plan);
		Task<int> DeletePlan(int id);
		Task<int> UpdatePlan(Plan plan);
        Task<List<Plan>> GetAllPlansWithPrograms();




    }
}
