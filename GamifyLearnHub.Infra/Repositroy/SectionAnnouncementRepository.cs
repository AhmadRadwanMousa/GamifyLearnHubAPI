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
    public class SectionAnnouncementRepository : ISectionAnnouncementRepository
    {
        private readonly IDbContext _dbContext;

        public SectionAnnouncementRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Sectionannoncment>> GetAllSectionAnnouncements()
        {
            var result = await _dbContext.Connection.QueryAsync<Sectionannoncment>(
                "SectionAnnouncement_Package.GetAllSectionAnnouncements",
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<Sectionannoncment> GetSectionAnnouncementById(decimal announcementId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_announcement_id", announcementId, DbType.Decimal, ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Sectionannoncment>(
                "SectionAnnouncement_Package.GetSectionAnnouncementById",
                parameters,
            commandType: CommandType.StoredProcedure
            );

            return result.FirstOrDefault();
        }

        public async Task<decimal> CreateSectionAnnouncement(Sectionannoncment sectionAnnouncement)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_section_id", sectionAnnouncement.Sectionid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_announcement_message", sectionAnnouncement.Annoncmentmessage, DbType.String, ParameterDirection.Input);
            parameters.Add("p_announcement_date", sectionAnnouncement.Annoncmentdate, DbType.Date, ParameterDirection.Input);
            parameters.Add("created_id", dbType: DbType.Decimal, direction: ParameterDirection.Output);
            parameters.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync(
                "SectionAnnouncement_Package.CreateSectionAnnouncement",
                parameters,
            commandType: CommandType.StoredProcedure
            );

            return parameters.Get<decimal>("created_id");
        }

        public async Task<int> UpdateSectionAnnouncement(Sectionannoncment sectionAnnouncement)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_announcement_id", sectionAnnouncement.Sectionannoncmentid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_section_id", sectionAnnouncement.Sectionid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("p_announcement_message", sectionAnnouncement.Annoncmentmessage, DbType.String, ParameterDirection.Input);
            parameters.Add("p_announcement_date", sectionAnnouncement.Annoncmentdate, DbType.Date, ParameterDirection.Input);
            parameters.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync(
                "SectionAnnouncement_Package.UpdateSectionAnnouncement",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return parameters.Get<int>("rows_affected");
        }

        public async Task<int> DeleteSectionAnnouncement(decimal announcementId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_announcement_id", announcementId, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync(
                "SectionAnnouncement_Package.DeleteSectionAnnouncement",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return parameters.Get<int>("rows_affected");
        }
    }
}
