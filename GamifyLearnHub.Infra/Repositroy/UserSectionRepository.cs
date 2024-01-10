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

namespace GamifyLearnHup.Infra.Repository
{
    public class UserSectionRepository : IUserSectionRepository
    {
        private readonly IDbContext _dbContext;

        public UserSectionRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Usersection>> GetAllUserSections()
        {
            var result = await _dbContext.Connection.QueryAsync<Usersection, User, Usersection>(
                "UserSection_Package.GetAllUserSections",
                (usersection, user) => {
                    if (usersection.User == null) {
                        usersection.User = user;
                    }
                    return usersection;
                },
                splitOn:"Userid",
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<Usersection> GetUserSectionById(decimal userSectionId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_user_section_id", userSectionId, DbType.Decimal, ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Usersection>(
                "UserSection_Package.GetUserSectionById",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.FirstOrDefault();
        }

        public async Task<decimal> CreateUserSection(Usersection userSection)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_user_id", userSection.Userid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_section_id", userSection.Sectionid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_enrollment_date", userSection.Enrollmentdate, DbType.Date, ParameterDirection.Input);
            parameters.Add("p_student_mark", userSection.Studentmark, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("created_id", dbType: DbType.Decimal, direction: ParameterDirection.Output);
            parameters.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync(
                "UserSection_Package.CreateUserSection",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return parameters.Get<decimal>("created_id");
        }

        public async Task<int> UpdateUserSection(Usersection userSection)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_user_section_id", userSection.Usersectionid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_user_id", userSection.Userid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_section_id", userSection.Sectionid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_enrollment_date", userSection.Enrollmentdate, DbType.Date, ParameterDirection.Input);
            parameters.Add("p_student_mark", userSection.Studentmark, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync(
                "UserSection_Package.UpdateUserSection",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return parameters.Get<int>("rows_affected");
        }

        public async Task<int> DeleteUserSection(decimal userSectionId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_user_section_id", userSectionId, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync(
                "UserSection_Package.DeleteUserSection",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return parameters.Get<int>("rows_affected");
        }

        public async Task<List<User>> GetAllUserStudents()
        {
            var result = await _dbContext.Connection.QueryAsync<User>("UserSection_Package.GetAllUserStudents", commandType: CommandType.StoredProcedure);

            return result.ToList();

        }


        public async Task<IEnumerable<Usersection>> GetUserSectionsBySectionId(decimal sectionId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_section_id", sectionId, DbType.Decimal, ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Usersection, User, Usersection>(
                "UserSection_Package.GetUserSectionsById",
                (userSection, user) =>
                {
                    userSection.User = user;
                    return userSection;
                },
                parameters,
                splitOn: "UserId",
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<IEnumerable<User>> GetUsersBySectionId(decimal sectionId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_section_id", sectionId, DbType.Decimal, ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<User>(
                "UserSection_Package.GetUsersBySectionId",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<int> SetUserAssignmentMark(int mark, int assignmentId, int studentId)
        {
            var p = new DynamicParameters();
            p.Add("mark",mark, DbType.Int32,direction: ParameterDirection.Input);
            p.Add("assignment_id", assignmentId, DbType.Int32,direction: ParameterDirection.Input);
            p.Add("user_id", studentId, DbType.Int32,direction: ParameterDirection.Input);
            p.Add("rows_effected", DbType.Int32,direction: ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync
                ("UserSection_Package.SetUserAssignmentMark", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("rows_effected");
        }
    }
}
