﻿using Dapper;
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
            var result = await _dbContext.Connection.QueryAsync<Usersection>(
                "UserSection_Package.GetAllUserSections",
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

        public async Task CreateUserSection(Usersection userSection)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_user_id", userSection.Userid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_section_id", userSection.Sectionid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_enrollment_date", userSection.Enrollmentdate, DbType.Date, ParameterDirection.Input);
            parameters.Add("p_student_mark", userSection.Studentmark, DbType.Decimal, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync(
                "UserSection_Package.CreateUserSection",
            parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task UpdateUserSection(Usersection userSection)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_user_section_id", userSection.Usersectionid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_user_id", userSection.Userid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_section_id", userSection.Sectionid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_enrollment_date", userSection.Enrollmentdate, DbType.Date, ParameterDirection.Input);
            parameters.Add("p_student_mark", userSection.Studentmark, DbType.Decimal, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync(
                "UserSection_Package.UpdateUserSection",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task DeleteUserSection(decimal userSectionId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_user_section_id", userSectionId, DbType.Decimal, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync(
                "UserSection_Package.DeleteUserSection",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}