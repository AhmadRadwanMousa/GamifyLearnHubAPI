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
    public class ExamRepository : IExamRepository
    {
        private readonly IDbContext _dbContext;

        public ExamRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateExam(Exam exam)
        {
            var p = new DynamicParameters();
            p.Add("p_section_id", exam.Sectionid, dbType:DbType.Int32, direction:ParameterDirection.Input);
            p.Add("p_exam_type", exam.Examtype, dbType:DbType.String, direction:ParameterDirection.Input);
            p.Add("p_exam_date", exam.Examdate, dbType:DbType.Date, direction:ParameterDirection.Input);
            p.Add("p_exam_mark", exam.Exammark, dbType:DbType.Int32, direction:ParameterDirection.Input);
            p.Add("p_exam_status", exam.Examstatus, dbType:DbType.Int32, direction:ParameterDirection.Input);
            p.Add("p_open_at", exam.Openat, dbType:DbType.DateTime, direction:ParameterDirection.Input);
            p.Add("p_close_at", exam.Closeat, dbType:DbType.DateTime, direction:ParameterDirection.Input);
            p.Add("created_id", dbType:DbType.Int32, direction:ParameterDirection.Output);
            p.Add("rows_affected", dbType:DbType.Int32, direction:ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("Exam_Package.CreateExam", p,commandType:CommandType.StoredProcedure);

            return p.Get<int>("created_id");

        }

        public async Task<int> DeleteExam(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_exam_id",id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("rows_affected",dbType: DbType.Int32, direction: ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("Exam_Package.DeleteExam", p, commandType:CommandType.StoredProcedure);
            return p.Get<int>("rows_affected");
        }

        public async Task<List<Exam>> GetAllExams()
        {
            var result = await _dbContext.Connection.QueryAsync<Exam>("Exam_Package.GetAllExams",commandType:CommandType.StoredProcedure);

            return result.ToList();

        }

        public async Task<Exam> GetExamById(int id)
        {
            var p = new DynamicParameters();

            p.Add("p_exam_id",id,dbType:DbType.Int32, direction:ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Exam>("Exam_Package.GetExamById",p,commandType:CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<int> UpdateExam(Exam exam)
        {
            var p = new DynamicParameters();
            p.Add("p_exam_id", exam.Examid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_section_id", exam.Sectionid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_exam_type", exam.Examtype, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_exam_date", exam.Examdate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("p_exam_mark", exam.Exammark, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_exam_status", exam.Examstatus, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_open_at", exam.Openat, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_close_at", exam.Closeat, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("Exam_Package.UpdateExam", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("rows_affected");
        }
    }
}
