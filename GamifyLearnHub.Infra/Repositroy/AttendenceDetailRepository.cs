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
    public class AttendenceDetailRepository : IAttendenceDetailRepository
    {

        private readonly IDbContext _dbContext;

        public AttendenceDetailRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAttendenceDetails(Attendencedetail attendencedetail)
        {
            var p = new DynamicParameters();

            p.Add("user_id", attendencedetail.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("is_attended", attendencedetail.Isattended, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("attendence_id", attendencedetail.Attendenceid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("created_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("AttendenceDetails_Package.CreateAttendenceDetails", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("created_id");
        }

        public async Task<int> DeleteAttendenceDetails(int id)
        {
            var p = new DynamicParameters();

            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("AttendenceDetails_Package.DeleteAttendenceDetails", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("RowsAffected");

        }

        public async Task<List<Attendencedetail>> GetAllAttendenceDetails()
        {
            var result = await _dbContext.Connection.QueryAsync<Attendencedetail>("AttendenceDetails_Package.GetAllAttendenceDetails", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Attendencedetail> GetAttendenceDetailsById(int id)
        {
            var p = new DynamicParameters();

            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Attendencedetail>("AttendenceDetails_Package.GetAttendenceDetailsById",p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<int> UpdateAttendenceDetails(Attendencedetail attendencedetail)
        {
            var p = new DynamicParameters();

            p.Add("id", attendencedetail.Attendenceid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("user_id", attendencedetail.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("is_attended", attendencedetail.Isattended, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("attendence_id", attendencedetail.Attendenceid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("AttendenceDetails_Package.UpdateAttendenceDetails", p, commandType: CommandType.StoredProcedure);

            return p.Get<int>("RowsAffected");
        }
    }
}
