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
			IEnumerable<Plan> plans = _dBContext.Connection.Query<Plan>("Plan_Package.GetAllPlans", commandType: CommandType.StoredProcedure);
			return plans.ToList();
		}

		public async void CreatePlan(Plan plan)
		{
			var p = new DynamicParameters();
			p.Add("Plan_Name", plan.Planname, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("created_id", plan.Planid,dbType:DbType.Int32,direction: ParameterDirection.Input);
			_dBContext.Connection.ExecuteAsync("Plan_Package.CreatePlan", p, commandType: CommandType.StoredProcedure);

		}

		public async void DeletePlan(int id)
		{
			var p = new DynamicParameters();
			p.Add("id", id, dbType:DbType.Int32, direction: ParameterDirection.Input);
			_dBContext.Connection.ExecuteAsync("Plan_Package.DeletePlan",p,commandType:CommandType.StoredProcedure);
		}


		public async Task<Plan> GetPlanById(int id)
		{
			var p = new DynamicParameters();
			p.Add("id", id , dbType:DbType.Int32, direction: ParameterDirection.Input);
			var result = await _dBContext.Connection.QueryAsync<Plan>("Plan_Package.GetPlanById", p, commandType: CommandType.StoredProcedure);
			return result.FirstOrDefault();
		}

		public void UpdatePlan(Plan plan)
		{
			var p = new DynamicParameters();
			p.Add("Plan_Id", plan.Planid, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("Plan_Name", plan.Planname, dbType: DbType.String, direction: ParameterDirection.Input);
			_dBContext.Connection.ExecuteAsync("Plan_Package.UpdatePlan", p, commandType: CommandType.StoredProcedure);
		}
	}

	
	}

