using Dapper;
using GamifyLearnHub.Core.Common;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Repositroy
{
	public class ReportRepository : IReportRepository
	{
		private readonly IDbContext _dbContext;

		public ReportRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<InstructorReport>> GetAllReportsByInstructorId(int Id)
		{
			var p = new DynamicParameters();

			p.Add("p_SectionID", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

			var result = await _dbContext.Connection.QueryAsync<InstructorReport>("Report_Package.GetAllReports", p, commandType: CommandType.StoredProcedure);

			return result.ToList();
		}
	}

}

