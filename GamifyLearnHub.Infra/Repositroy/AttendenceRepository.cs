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
    public class AttendenceRepository : IAttendenceRepository
    {
        private readonly IDbContext _dbContext;

        public AttendenceRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAttendence(Attendence attendence)
        {
            var p = new DynamicParameters();

            p.Add("section_id", attendence.Sectionid, dbType: DbType.Int32, direction:ParameterDirection.Input);
            p.Add("attend_date", attendence.Attenddate, dbType: DbType.Date, direction:ParameterDirection.Input);
            p.Add("created_id",dbType: DbType.Int32, direction:ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("Attendence_Package.CreateAttendence", p, commandType:CommandType.StoredProcedure);

            return p.Get<int>("created_id");
        }

        public async Task<int> DeleteAttendence(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("Attendence_Package.DeleteAttendence", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("RowsAffected");

        }

        public async Task<List<Attendence>> GetAllAttendence()
        {
            var result = await _dbContext.Connection.QueryAsync<Attendence>("Attendence_Package.GetAllAttendence",commandType:CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<Attendence> GetAttendenceById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Attendence>("Attendence_Package.GetAttendenceById", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<int> UpdateAttendence(Attendence attendence)
        {
            var p = new DynamicParameters();

            p.Add("id", attendence.Attendenceid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("section_id", attendence.Sectionid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RowsAffected", attendence.Attenddate, dbType: DbType.Date, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("Attendence_Package.UpdateAttendence", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("RowsAffected");
        }
    }
}
