using Dapper;
using GamifyLearnHub.Core.Common;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
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
            p.Add("Program_Image", program.Programimage, dbType: DbType.String, direction: ParameterDirection.Input);
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

        //public async Task<List<Program>> GetAll()
        //{
        //    var result = await _dbContext.Connection.QueryAsync<Program , Plan , Educationalperiod , Coursesequence, Program>(
        //        "Program_Package.GetAllPrograms",
        //         (program , plan , educationalperiod , coursesequence) => {
        //             program.Plan = plan;
        //             program.Educationalperiod = educationalperiod;
        //             program.Coursesequences.Add(coursesequence);
        //             return program;
        //         },
        //          splitOn: "planid,educationalperiodid",
        //        commandType: CommandType.StoredProcedure);
        //    return result.ToList();
        //}




        public async Task<List<Program>> GetAll()
        {
            var result = await _dbContext.Connection.QueryAsync<Program, Plan, Educationalperiod, Coursesequence, Program>(
                "Program_Package.GetAllPrograms",
                (program, plan, educationalPeriod, courseSequence) =>
                {
                    program.Plan = plan;
                    program.Educationalperiod = educationalPeriod;

                    if (program.Coursesequences == null)
                    {
                        program.Coursesequences = new List<Coursesequence>();
                    }

                    program.Coursesequences.Add(courseSequence);

                    return program;
                },
                splitOn: "planid,educationalperiodid,coursesequenceid", 
                commandType: CommandType.StoredProcedure
            );

            var groupedPrograms = result
                .GroupBy(p => p.Programid)
                .Select(group =>
                {
                    var program = group.First();
                    program.Coursesequences = group
                        .SelectMany(p => p.Coursesequences)
                        .ToList();
                    return program;
                })
                .ToList();

            return groupedPrograms;
        }

        public async Task<int> GetNumberOfStudentsInProgram(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("num_students", dbType:DbType.Int32,direction:ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("Program_Package.GetNumberOfStudentsInProgram",p,commandType:CommandType.StoredProcedure);
            return p.Get<int>("num_students");

        }

        public async Task<Program> GetProgramById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Program, Plan,Educationalperiod, Program>(
                "Program_Package.GetProgramById",
                (program, plan, educationalperiod) => {

                    if (program.Plan == null) {

                        program.Plan = plan;
                    }
                    if (program.Educationalperiod == null) {

                        program.Educationalperiod = educationalperiod;
                    }
                        return program;
                },
                p,
                splitOn: "planid, educationalperiodid",
                commandType:CommandType.StoredProcedure);

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
            p.Add("Program_Image", program.Programimage, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("updated_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("Program_Package.UpdateProgram", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("rows_affected");
        }

        public async Task<List<ProgramsByPlanId>> GetAllProgramsWithPlanId(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<ProgramsByPlanId>("Program_Package.GetAllProgramsByPlanId", p ,commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<Program>> GetAllUserPrograms(int userId)
        {
            var p = new DynamicParameters();
            p.Add("user_id",userId, dbType:DbType.Int32, direction: ParameterDirection.Input);
            var resul= await _dbContext.Connection.QueryAsync<Program>("Program_Package.GetUserPrograms", p, commandType: CommandType.StoredProcedure);
            return resul.ToList();
        }
    }
}
