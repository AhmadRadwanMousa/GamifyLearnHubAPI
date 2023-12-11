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
using static System.Collections.Specialized.BitVector32;

namespace GamifyLearnHub.Infra.Repositroy
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly IDbContext _dbContext;
        public AssignmentRepository(IDbContext dbContext)
        {
            _dbContext=dbContext;
        }
        public async Task<int> CreateAssignment(Assignment assignment)
        {
            var p = new DynamicParameters();
            p.Add("assignment_Name",assignment.Assignmentname,dbType:DbType.String,direction:ParameterDirection.Input);
            p.Add("assignmentDesc", assignment.Assignmentdescription,dbType:DbType.String,direction:ParameterDirection.Input);
            p.Add("assignment_Mark", assignment.Assignmentmark,dbType:DbType.Int32,direction:ParameterDirection.Input);
            p.Add("assignment_DeadLine", assignment.Assignmentdeadline,dbType:DbType.Date,direction:ParameterDirection.Input);
            p.Add("section_Id", assignment.Sectionid,dbType:DbType.Int32,direction:ParameterDirection.Input);
            p.Add("assignment_Id", assignment.Assignmentid,dbType:DbType.Int32,direction:ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("Assignment_Package.CreateAssignment",p,commandType:CommandType.StoredProcedure);
            return p.Get<int>("assignment_Id");
        }

        public async Task<int> DeleteAssignment(int assignmentID)
        {
            var p = new DynamicParameters();
            p.Add("assignment_Id", assignmentID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("rows_effected",  dbType: DbType.Int32, direction: ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("Assignment_Package.DeleteAssignment", p,commandType:CommandType.StoredProcedure);
            return p.Get<int>("rows_effected");
        }

        public async Task<List<Assignment>> GetAssignmentBySectionId(int sectionId)
        {
            var p = new DynamicParameters();
            p.Add("section_Id", sectionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Assignment>("Assignment_Package.GetAssignemntsBySectionId", p,commandType:CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<int> UpdateAssignment(Assignment assignment)
        {
            var p = new DynamicParameters();
            p.Add("assignment_Id", assignment.Assignmentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("assignment_Name", assignment.Assignmentname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("assignmentDesc", assignment.Assignmentdescription, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("assignment_Mark", assignment.Assignmentmark, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("assignment_DeadLine", assignment.Assignmentdeadline, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("section_Id", assignment.Sectionid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("rows_effected",  dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.QueryAsync("Assignment_Package.UpdateAssignment", p,commandType:CommandType.StoredProcedure);
            return p.Get<int>("rows_effected");
        }
    }
}
