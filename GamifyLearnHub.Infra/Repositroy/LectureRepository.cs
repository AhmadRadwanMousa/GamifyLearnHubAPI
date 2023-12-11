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
    public class LectureRepository : ILectureRepository
    {
        private readonly IDbContext _dbContext;

        public LectureRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Lecture>> GetAllLectures()
        {
            var result = await _dbContext.Connection.QueryAsync<Lecture>(
                "Lecture_Package.GetAllLectures",
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<Lecture> GetLectureById(decimal lectureId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_lecture_id", lectureId, DbType.Decimal, ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Lecture>(
                "Lecture_Package.GetLectureById",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.FirstOrDefault();
        }

        public async Task<decimal> CreateLecture(Lecture lecture)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_course_section_id", lecture.Coursesectionid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_lecture_name", lecture.Lecturename, DbType.String, ParameterDirection.Input);
            parameters.Add("p_lecture_file", lecture.Lecturefile, DbType.String, ParameterDirection.Input);
            parameters.Add("p_lecture_duration", lecture.Lectureduration, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("created_id", dbType: DbType.Decimal, direction: ParameterDirection.Output);
            parameters.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync(
                "Lecture_Package.CreateLecture",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return parameters.Get<decimal>("created_id");
        }

        public async Task<int> UpdateLecture(Lecture lecture)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_lecture_id", lecture.Lectureid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_lecture_name", lecture.Lecturename, DbType.String, ParameterDirection.Input);
            parameters.Add("p_lecture_file", lecture.Lecturefile, DbType.String, ParameterDirection.Input);
            parameters.Add("p_lecture_duration", lecture.Lectureduration, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync(
                "Lecture_Package.UpdateLecture",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return parameters.Get<int>("rows_affected");
        }

        public async Task<int> DeleteLecture(decimal lectureId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_lecture_id", lectureId, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync(
                "Lecture_Package.DeleteLecture",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return parameters.Get<int>("rows_affected");
        }
    }

}
