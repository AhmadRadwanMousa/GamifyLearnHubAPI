using Dapper;
using GamifyLearnHub.Core.Common;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Repository
{
	public class PlanRepository : IPlanRepository
	{
		private readonly IDbContext _dBContext;
		public PlanRepository(IDbContext dBContext)
		{
			this._dBContext = dBContext;
		}
		public async Task<List<Plan>> GetAllPlans()
		{
			IEnumerable<Plan> plans = await _dBContext.Connection.QueryAsync<Plan>("Plan_Package.GetAllPlans", commandType: CommandType.StoredProcedure);
			return plans.ToList();
		}

		public async Task<int> CreatePlan(Plan plan)
		{
			var p = new DynamicParameters();
			p.Add("Plan_Name", plan.Planname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("plan_image", plan.Planimage, dbType: DbType.String, direction: ParameterDirection.Input);;
            p.Add("created_id", plan.Planid, dbType: DbType.Int32, direction: ParameterDirection.Output);
			p.Add("rows_affected", DbType.Int32, direction: ParameterDirection.Output);
			await _dBContext.Connection.ExecuteAsync("Plan_Package.CreatePlan", p, commandType: CommandType.StoredProcedure);
			return p.Get<int>("created_id");
		}

		public async Task<int> DeletePlan(int id)
		{
			var p = new DynamicParameters();
			p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("deleted_id", DbType.Int32, direction: ParameterDirection.Output);
			p.Add("rows_affected", DbType.Int32, direction: ParameterDirection.Output);

			await _dBContext.Connection.ExecuteAsync("Plan_Package.DeletePlan", p, commandType: CommandType.StoredProcedure);
			return p.Get<int>("rows_affected");
		}


		public async Task<Plan> GetPlanById(int id)
		{
			var p = new DynamicParameters();
			p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			var result = await _dBContext.Connection.QueryAsync<Plan>("Plan_Package.GetPlanById", p, commandType: CommandType.StoredProcedure);
			return result.FirstOrDefault();
		}

		public async Task<int> UpdatePlan(Plan plan)
		{
			var p = new DynamicParameters();
			p.Add("Plan_Id", plan.Planid, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("Plan_Name", plan.Planname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("plan_image", plan.Planimage, dbType: DbType.String, direction: ParameterDirection.Input); ;

            p.Add("updated_id", DbType.Int32, direction: ParameterDirection.Output);
			p.Add("rows_affected", DbType.Int32, direction: ParameterDirection.Output);

			await _dBContext.Connection.ExecuteAsync("Plan_Package.UpdatePlan", p, commandType: CommandType.StoredProcedure);
			return p.Get<int>("rows_affected");

		}

        public async Task<List<Plan>> GetAllPlansWithPrograms()
        {
            var plansWithPrograms = await _dBContext.Connection.QueryAsync<Plan, Program, Plan>(
                "Plan_Package.GetAllPlansWithPrograms",
                (plan, program) =>
                {
                    if (plan.Programs == null)
                    {
                        plan.Programs = new List<Program>();
                    }

                    if (program != null) 
                    {
                        plan.Programs.Add(program);
                    }

                    return plan;
                },
                splitOn: "planid,programid",
                commandType: CommandType.StoredProcedure);

            var groupedPlans = plansWithPrograms
                .GroupBy(p => p.Planname)
                .Select(g => new Plan
                {
                    Planid = g.First().Planid,
                    Planname = g.Key,
                    Planimage = g.First().Planimage,
                    Programs = g.SelectMany(p => p.Programs).Where(p => p != null).ToList()
                })
                .ToList();

            return groupedPlans;
        }


    }


}

