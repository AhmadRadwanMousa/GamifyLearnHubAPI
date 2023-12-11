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

namespace GamifyLearnHub.Infra.Repositroy
{
    public class AssignmentSolutionDetailsRepository : IAssignmentSolutionDetailsRepository
    {
        private readonly IDbContext _dbContext;
        public AssignmentSolutionDetailsRepository(IDbContext dbContext)
        {
            _dbContext= dbContext;  
        }

        public async Task<int> CreateAssignmentSolutionDetails(Assignmentsolutiondetail assignmentsolutiondetail)
        {
            var p = new DynamicParameters();
            p.Add("user_Id", assignmentsolutiondetail.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("assignment_Id", assignmentsolutiondetail.Assignmentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("assignmentSolution_Mark", assignmentsolutiondetail.Assignmentsolutionmark, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("assignmentSolutionDetails_Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
           await _dbContext.Connection.ExecuteAsync("AssignmentSolutionDetails_Package.CreateAssignmentSolutionDetails",p,commandType:CommandType.StoredProcedure);
           return p.Get<int>("assignmentSolutionDetails_Id");
        }

        public async Task<int> DeleteAssignmentSolutionDetails(int assignmentSolutionDetailsId)
        {
           var p = new DynamicParameters();
            p.Add("assignmentSolutionDetails_Id", assignmentSolutionDetailsId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("rows_effected", dbType: DbType.Int32, direction: ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("AssignmentSolutionDetails_Package.DeleteAssignmentSolutionDetails",p,commandType:CommandType.StoredProcedure);
            return p.Get<int>("rows_effected");

        }

        public async Task<Assignmentsolutiondetail> GetAssignmentsolutiondetailById(int assignmentSolutionDetailsId)
        {
          var p= new DynamicParameters();
            p.Add("assignmentSolutionDetails_Id", assignmentSolutionDetailsId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Assignmentsolutiondetail>("AssignmentSolutionDetails_Package.GetAssginmentSolutionById",
                p,commandType:CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<List<Assignmentsolutiondetail>> GetAssignmentSolutionDetailsByAssignmentId(int assignmentId)
        {
            var p = new DynamicParameters();
            p.Add("assignment_Id", assignmentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Assignmentsolutiondetail>("AssignmentSolutionDetails_Package.GetAssignmentSolutionDetailsByAssignmentID"
                ,p,commandType:CommandType.StoredProcedure);
            return result.ToList();

        }

        public async Task<int> UpdateAssignmentSolutionDetails(Assignmentsolutiondetail assignmentsolutiondetail)
        {
            var p = new DynamicParameters();
            p.Add("user_Id", assignmentsolutiondetail.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("assignment_Id", assignmentsolutiondetail.Assignmentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("assignmentSolution_Mark", assignmentsolutiondetail.Assignmentsolutionmark, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("assignmentSolutionDetails_Id", assignmentsolutiondetail.Assignmentsolutiondetailsid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("rows_effected", dbType: DbType.Int32, direction: ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("AssignmentSolutionDetails_Package.UpdateAssignmentSolutionDetails", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("rows_effected");
        }
    }
}
