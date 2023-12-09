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
    public class CourseRepository : ICourseRepository
    {
        private readonly IDbContext _dbContext;

        public CourseRepository(IDbContext dbContext) 
        {
            _dbContext = dbContext; 
        }


        public async Task<int> CreateCourse(Course course)
        {
            var p = new DynamicParameters();
            p.Add("Course_Level", course.Courselevel, DbType.String, direction: ParameterDirection.Input);
            p.Add("Course_Name", course.Coursename, DbType.String, direction: ParameterDirection.Input);
            p.Add("Course_Image", course.Courseimage, DbType.String, direction: ParameterDirection.Input);
            p.Add("Exam_Weight", course.Examweight, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Assignment_Weight", course.Assignmentweight, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Quizzez_Weight", course.Quizzezweight, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("created_id", DbType.Int32, direction: ParameterDirection.Output);
            p.Add("rows_affected", DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.ExecuteAsync("Course_Package.CreateCourse", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("created_id");
        }

        public async Task<int> DeleteCourse(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("deleted_id", DbType.Int32, direction: ParameterDirection.Output);
            p.Add("rows_affected", DbType.Int32, direction: ParameterDirection.Output);

            _dbContext.Connection.ExecuteAsync("Course_Package.DeleteCourse", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("rows_affected");
        }

        public async Task<List<Course>> GetAllCourses()
        {
            var result = await _dbContext.Connection.QueryAsync<Course>("Course_Package.GetAllCourses", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Course> GetCourseById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Course>("Course_Package.GetCourseById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<int> UpdateCourse(Course course)
        {
            var p = new DynamicParameters();
            p.Add("Course_Id", course.Courseid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Course_Level", course.Courselevel, DbType.String, direction: ParameterDirection.Input);
            p.Add("Course_Name", course.Coursename, DbType.String, direction: ParameterDirection.Input);
            p.Add("Course_Image", course.Courseimage, DbType.String, direction: ParameterDirection.Input);
            p.Add("Exam_Weight", course.Examweight, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Assignment_Weight", course.Assignmentweight, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Quizzez_Weight", course.Quizzezweight, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("updated_id", DbType.Int32, direction: ParameterDirection.Output);
            p.Add("rows_affected", DbType.Int32, direction: ParameterDirection.Output);

            _dbContext.Connection.ExecuteAsync("Course_Package.UpdateCourse", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("rows_affected");
        }
    }
}
