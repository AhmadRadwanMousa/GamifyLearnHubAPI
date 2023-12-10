using Dapper;
using GamifyLearnHub.Core.Common;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Repository
{
	public class EducationalPeriodRepository : IEducationalPeriodRepository
	{
		private readonly IDbContext _dBContext;

        public EducationalPeriodRepository(IDbContext dbContext)
        {
            this._dBContext = dbContext;
        }
        public async Task<List<Educationalperiod>> GetAllEducationalperiod()
		{
			IEnumerable<Educationalperiod> educationalPeriods = await _dBContext.Connection.QueryAsync<Educationalperiod>("EducationalPeriod_Package.GetAllEducationalPeriods", commandType: CommandType.StoredProcedure);
			return educationalPeriods.ToList();
		}
		public async Task<int> CreateEducationalperiod(Educationalperiod educationalPeriod)
		{
			var p = new DynamicParameters();
			p.Add("Start_Date", educationalPeriod.Startdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
			p.Add("End_Date", educationalPeriod.Enddate, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("created_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
			p.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);
			await _dBContext.Connection.ExecuteAsync("EducationalPeriod_Package.CreateEducationalPeriod", p, commandType: CommandType.StoredProcedure);
			return p.Get<int>("created_id");
		}

		public async Task<int> DeleteEducationalperiod(int id)
		{
			var p = new DynamicParameters();
			p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("deleted_id", DbType.Int32, direction: ParameterDirection.Output);
			p.Add("rows_affected", DbType.Int32, direction: ParameterDirection.Output);
			await _dBContext.Connection.ExecuteAsync("EducationalPeriod_Package.DeleteEducationalPeriod", p, commandType: CommandType.StoredProcedure);
			return p.Get<int>("rows_affected");
		}

		public async Task<Educationalperiod> GetEducationalperiodById(int id)
		{
			var p = new DynamicParameters();
			p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			var result = await _dBContext.Connection.QueryAsync<Educationalperiod>("EducationalPeriod_Package.GetEducationalPeriodById", p, commandType: CommandType.StoredProcedure);
			return result.FirstOrDefault();
		}

		public async Task<int> UpdateEducationalperiod(Educationalperiod educationalPeriod)
		{
			var p = new DynamicParameters();
			p.Add("EducationalPeriod_Id", educationalPeriod.Educationalperiodid, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("Start_Date", educationalPeriod.Startdate, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("End_Date", educationalPeriod.Enddate, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("updated_id", DbType.Int32, direction: ParameterDirection.Output);
			p.Add("rows_affected", DbType.Int32, direction: ParameterDirection.Output);

			await _dBContext.Connection.ExecuteAsync("EducationalPeriod_Package.UpdateEducationalPeriod", p, commandType: CommandType.StoredProcedure);
			return p.Get<int>("rows_affected");

		}
	}
}
