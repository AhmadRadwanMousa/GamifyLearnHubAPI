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
    public class CourseSequenceRepository : ICourseSequenceRepository
    {
        private readonly IDbContext _dbContext;

        public CourseSequenceRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateCourseSequence(Coursesequence coursesequence)
        {
            var p = new DynamicParameters();
            p.Add("Course_Id", coursesequence.Courseid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Program_Id", coursesequence.Programid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("PerviousCourse_Id", coursesequence.Perviouscourseid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Start_Date", coursesequence.Startdate, DbType.Date, direction: ParameterDirection.Input);
            p.Add("End_Date", coursesequence.Enddate, DbType.Date, direction: ParameterDirection.Input);
            p.Add("created_id", DbType.Int32, direction: ParameterDirection.Output);
            p.Add("rows_affected", DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.ExecuteAsync("CourseSequence_Package.CreateCourseSequence", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("created_id");
        }

        public async Task<int> DeleteCourseSequence(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("deleted_id", DbType.Int32, direction: ParameterDirection.Output);
            p.Add("rows_affected", DbType.Int32, direction: ParameterDirection.Output);

            _dbContext.Connection.ExecuteAsync("CourseSequence_Package.DeleteCourseSequence", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("rows_affected");
        }

        public async Task<List<Coursesequence>> GetAllCourseSequences()
        {
            var result = await _dbContext.Connection.QueryAsync<Coursesequence>("CourseSequence_Package.GetAllCourseSequences", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Coursesequence> GetCourseSequenceById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Coursesequence>("CourseSequence_Package.GetCourseSequenceById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<int> UpdateCourseSequence(Coursesequence coursesequence)
        {
            var p = new DynamicParameters();
            p.Add("CourseSequence_Id", coursesequence.Coursesequenceid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Course_Id", coursesequence.Courseid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Program_Id", coursesequence.Programid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("PerviousCourse_Id", coursesequence.Perviouscourseid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Start_Date", coursesequence.Startdate, DbType.Date, direction: ParameterDirection.Input);
            p.Add("End_Date", coursesequence.Enddate, DbType.Date, direction: ParameterDirection.Input);
            p.Add("updated_id", DbType.Int32, direction: ParameterDirection.Output);
            p.Add("rows_affected", DbType.Int32, direction: ParameterDirection.Output);

            _dbContext.Connection.ExecuteAsync("CourseSequence_Package.UpdateCourseSequence", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("rows_affected");
        }
    }
}
