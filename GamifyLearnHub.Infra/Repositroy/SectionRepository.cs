﻿using Dapper;
using GamifyLearnHub.Core.Common;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Repository;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Repository
{
    public class SectionRepository : ISectionRepository
    {
        private readonly IDbContext _dbContext;

        public SectionRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Section>> GetAllSections()
        {
            var result = await _dbContext.Connection.QueryAsync<Section>(
                "Section_Package.GetAllSections",
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<Section> GetSectionById(decimal sectionId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_section_id", sectionId, DbType.Decimal, ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Section>(
                "Section_Package.GetSectionById",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result.FirstOrDefault();
        }

        public async Task<int> CreateSection(Section section)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_section_name", section.Sectionname, DbType.String, ParameterDirection.Input);
            parameters.Add("p_user_id", section.Userid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_course_sequence_id", section.Coursesequenceid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_section_size", section.Sectionsize, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("created_id", dbType: DbType.Decimal, direction: ParameterDirection.Output);
            parameters.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("Section_Package.CreateSection", parameters, commandType: CommandType.StoredProcedure);

            int createdId = parameters.Get<int>("created_id");
            return createdId;
        }

        public async Task<int> UpdateSection(decimal sectionId, Section section)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_section_id", sectionId, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_section_name", section.Sectionname, DbType.String, ParameterDirection.Input);
            parameters.Add("p_user_id", section.Userid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_course_sequence_id", section.Coursesequenceid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_section_size", section.Sectionsize, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("updated_id", dbType: DbType.Decimal, direction: ParameterDirection.Output);
            parameters.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("Section_Package.UpdateSection", parameters, commandType: CommandType.StoredProcedure);

            int rowsAffected = parameters.Get<int>("rows_affected");
            return rowsAffected;
        }

        public async Task<int> DeleteSection(decimal sectionId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_section_id", sectionId, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("deleted_id", dbType: DbType.Decimal, direction: ParameterDirection.Output);
            parameters.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("Section_Package.DeleteSection", parameters, commandType: CommandType.StoredProcedure);

            sectionId = parameters.Get<decimal>("deleted_id"); // Update the SectionId in the input object
            return parameters.Get<int>("rows_affected");
        }
    }
}
