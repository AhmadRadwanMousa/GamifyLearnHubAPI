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

        public async Task<AdminDetails> GetAdminStatisticsReport()
        {
            var p = new DynamicParameters();
            p.Add("admins_count",dbType:DbType.Int32,direction:ParameterDirection.Output);
            p.Add("instructors_count", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("learners_count", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("instructors_requests", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("coupons_count", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("plans_count", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("programs_count", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("courses_count", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("payments_count", dbType: DbType.Int32, direction: ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync
                ("Admin_report_Package.GetAdminStatisticsReport", p, commandType: CommandType.StoredProcedure);
            var adminReport = new AdminDetails()
            {
                Adminscount = p.Get<int>("admins_count"),
                Instructorscount = p.Get<int>("instructors_count"),
                Learnercount = p.Get<int>("learners_count"),
                Instructorsrequests = p.Get<int>("instructors_requests"),
                Couponscount = p.Get<int>("coupons_count"),
                Planscount = p.Get<int>("plans_count"),
                Programscount = p.Get<int>("programs_count"),
                Coursescount = p.Get<int>("courses_count"),
                Paymentscount = p.Get<int>("payments_count")
            };
            return adminReport;
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
