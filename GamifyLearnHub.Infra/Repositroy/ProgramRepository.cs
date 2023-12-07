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
    public class ProgramRepository : IProgramRepository
    {
        private readonly IDbContext _dbContext;

        public ProgramRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateProgram(Program program)
        {
            var p = new DynamicParameters();
            p.Add("Program_Name", program.Programname, dbType:DbType.String, direction:ParameterDirection.Input);
            p.Add("Program_Description", program.Programdescription, dbType:DbType.String, direction:ParameterDirection.Input);
            p.Add("Plan_Id", program.Planid, dbType:DbType.Int32, direction:ParameterDirection.Input);
            p.Add("Program_Syllabus", program.Programsyllabus, dbType:DbType.String, direction:ParameterDirection.Input);
            p.Add("Educational_PeriodId", program.Educationalperiodid, dbType:DbType.Int32, direction:ParameterDirection.Input);
            p.Add("Program_Price", program.Programprice, dbType:DbType.Int32, direction:ParameterDirection.Input);
            p.Add("Program_Sale", program.Programsale, dbType:DbType.Int32, direction:ParameterDirection.Input);
            p.Add("created_id", dbType:DbType.Int32, direction:ParameterDirection.Output);
            p.Add("rows_affected", dbType:DbType.Int32, direction:ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("Program_Package.CreateProgram",p,commandType: CommandType.StoredProcedure);
            
            return p.Get<int>("created_id");
        }

        public async Task<int> DeleteProgram(int id)
        {
            var p = new DynamicParameters();

            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("deleted_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("Program_Package.DeleteProgram", p, commandType: CommandType.StoredProcedure);
            
            return p.Get<int>("rows_affected");
        }

        public async Task<List<Program>> GetAll()
        {
            var result = await _dbContext.Connection.QueryAsync<Program>("Program_Package.GetAllPrograms", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Program> GetProgramById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Program>("Program_Package.GetProgramById",p,commandType:CommandType.StoredProcedure);

            return result.FirstOrDefault();
            
        }

        public async Task<int> UpdateProgram(Program program)
        {
            var p = new DynamicParameters();
            p.Add("Program_Id", program.Programid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Program_Name", program.Programname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Program_Description", program.Programdescription, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Plan_Id", program.Planid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Program_Syllabus", program.Programsyllabus, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Educational_PeriodId", program.Educationalperiodid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Program_Price", program.Programprice, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Program_Sale", program.Programsale, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("updated_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("Program_Package.UpdateProgram", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("rows_affected");
        }
    }
}
