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

        public async Task CreateSection(Section section)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_section_name", section.Sectionname, DbType.String, ParameterDirection.Input);
            parameters.Add("p_user_id", section.Userid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_course_sequence_id", section.Coursesequenceid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_section_size", section.Sectionsize, DbType.Decimal, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync(
                "Section_Package.CreateSection",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task UpdateSection(Section section)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_section_id", section.Sectionid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_section_name", section.Sectionname, DbType.String, ParameterDirection.Input);
            parameters.Add("p_user_id", section.Userid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_course_sequence_id", section.Coursesequenceid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_section_size", section.Sectionsize, DbType.Decimal, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync(
                "Section_Package.UpdateSection",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task DeleteSection(decimal sectionId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_section_id", sectionId, DbType.Decimal, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync(
                "Section_Package.DeleteSection",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
