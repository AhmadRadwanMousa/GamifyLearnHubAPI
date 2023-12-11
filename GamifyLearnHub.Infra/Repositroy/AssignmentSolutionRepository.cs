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
    public class AssignmentSolutionRepository : IAssignmentSolutionRepository
    {
        private readonly IDbContext _dbContext;
        public AssignmentSolutionRepository(IDbContext dbContext)
        {
            _dbContext=dbContext;   
        }
        public async Task<int> CreateAssignmentSolution(Assignmentsolution assignmentsolution)
        {
            var p = new DynamicParameters();
            p.Add("assignmentSolution_Id",dbType:DbType.Int32,direction:ParameterDirection.Output);
            p.Add("assignment_Id",assignmentsolution.Assignmentid,dbType:DbType.Int32,direction:ParameterDirection.Input);
            p.Add("user_Id", assignmentsolution.Userid,dbType:DbType.Int32,direction:ParameterDirection.Input);
            p.Add("assignmetSolution_Value", assignmentsolution.Assignmentsolutionvalue,dbType:DbType.String,direction:ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("AssignmentSolution_Package.CreateAssignmentSolution",p,commandType:CommandType.StoredProcedure);
            return p.Get<int>("assignmentSolution_Id");
               
        }

        public async Task<int> DeleteAssignmentSolution(int assignmentSolutionId)
        {
            var p = new DynamicParameters();
            p.Add("assignmentSolution_Id",assignmentSolutionId,dbType:DbType.Int32,direction:ParameterDirection.Input);
            p.Add("rows_effected", dbType: DbType.Int32, direction: ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("AssignmentSolution_Package.DeleteAssginmentSolution",p,commandType:CommandType.StoredProcedure);
            return p.Get<int>("rows_effected");
        }

        public async Task<List<Assignmentsolution>> GetAssignmentSolutionByAssignmentId(int assignmentId)
        {
            var p = new DynamicParameters();
            p.Add("assignment_Id", assignmentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Assignmentsolution>("AssignmentSolution_Package.GetAssginmentSolutionByAssignmentID",p,commandType:CommandType.StoredProcedure);
            return result.ToList();

        }

        public async Task<int> UpdateAssignmentSolution(Assignmentsolution assignmentsolution)
        {
            var p = new DynamicParameters();
            p.Add("assignmentSolution_Id",assignmentsolution.Assignmentsolutionid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("assignment_Id", assignmentsolution.Assignmentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("user_Id", assignmentsolution.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("assignmetSolution_Value", assignmentsolution.Assignmentsolutionvalue, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("rows_effected", dbType: DbType.Int32, direction: ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("AssignmentSolution_Package.UpdateAssginmentSolution", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("rows_effected");
        }
    }
}
