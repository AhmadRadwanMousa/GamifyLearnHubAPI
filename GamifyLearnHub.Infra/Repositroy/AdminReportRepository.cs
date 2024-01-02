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
    public class AdminReportRepository : IAdminReportRepository
    {
        private readonly IDbContext _dbContext;
        public AdminReportRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AdminReportSections>> GetAllSectionsReport()
        {
            var result = await _dbContext.Connection.QueryAsync<AdminReportSections>("Admin_report_Package.GetAllSectionsReport", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<AdminReportStudents>> GetAllStudentsReport()
        {
            var result = await _dbContext.Connection.QueryAsync<AdminReportStudents>("Admin_report_Package.GetAllStudentsReport",commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<AdminReportStudentsDetails>> GetAllStudentsReportDetails(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<AdminReportStudentsDetails>("Admin_report_Package.GetStudentReportByUserId",p,commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
