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
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly IDbContext _dbContext;
        public  AnnouncementRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAnnouncement(Announcement announcement)
        {

            var p = new DynamicParameters();
            p.Add("p_declaration", announcement.Declaration , dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_sectionid", announcement.Sectionid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("Announcement_Package.CreateAnnouncement", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("p_rows_affected");
        }

        public async Task<int> DeleteAnnouncement(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_announcementid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_rows_affected", DbType.Int32, direction: ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("Announcement_Package.DeleteAnnouncement", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("p_rows_affected");
        }

        public async Task<List<Announcement>> GetAllAnnouncements()
        {
           var result = await _dbContext.Connection.QueryAsync<Announcement>("Announcement_Package.GetAllAnnouncements", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Announcement> GetAnnouncementById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_announcementid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Announcement>("Announcement_Package.GetAnnouncementById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<List<Announcement>> GetAnnouncementsBySectionId(int sectionId)
        {
            var p = new DynamicParameters();
            p.Add("section_Id", sectionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Announcement>("Announcement_Package.GetAnnouncementsBySectionId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<int> UpdateAnnouncement(Announcement announcement)
        {
            var p = new DynamicParameters();
            p.Add("p_announcementid", announcement.Announcementid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_declaration", announcement.Declaration, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_sectionid", announcement.Sectionid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("Announcement_Package.UpdateAnnouncement", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("p_rows_affected");
        }
    }
}
