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
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbContext _dbContext;
        public RoleRepository(IDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public async Task<int> CreateRole(string roleName)
        {
            var p = new DynamicParameters();
            p.Add("Role_name",roleName,dbType:DbType.String,ParameterDirection.Input);
            p.Add("created_id",dbType:DbType.Int32,direction:ParameterDirection.Output);
            p.Add("rows_affected",dbType:DbType.Int32,direction:ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("Role_Package.CreateRole",p,commandType:CommandType.StoredProcedure);
            int newId = p.Get<int>("created_id");
            return newId;

        }

        public async Task<int> DeleteRole(int roleId)
        {
           var p = new DynamicParameters();
            p.Add("id",roleId,DbType.Int32,direction:ParameterDirection.Input);
            p.Add("rows_affected",DbType.Int32,direction:ParameterDirection.Output);
            p.Add("deleted_id",DbType.Int32,direction:ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("Role_Package.DeleteRole",p,commandType:CommandType.StoredProcedure);
            int rows_effected = p.Get<int>("rows_affected");
            int deletedId = p.Get<int>("deleted_id");
            return rows_effected;

        }

        public async Task<List<Role>> GetAllRoles()
        {
            var result = await _dbContext.Connection.QueryAsync<Role>("Role_Package.GetAllRoles",commandType:CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Role> GetRoleById(int roleId)
        {
            var p = new DynamicParameters();
            p.Add("id",roleId,DbType.Int32,direction:ParameterDirection.Input);
            var result =await _dbContext.Connection.QueryAsync<Role>("Role_Package.GetRoleById",p,commandType:CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public async Task<int> UpdateRole(Role role)
        {
            var p = new DynamicParameters();
            p.Add("Role_Id", role.Roleid,dbType:DbType.Int32,direction:ParameterDirection.Input);
            p.Add("Role_name", role.Rolename,dbType:DbType.String,direction:ParameterDirection.Input);
            p.Add("rows_affected",DbType.Int32,direction:ParameterDirection.Output);
            p.Add("updated_id",DbType.Int32,direction:ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("Role_Package.UpdateRole", p,commandType:CommandType.StoredProcedure);
            int rows_effected = p.Get<int>("rows_affected");
            int updatedId = p.Get<int>("updated_id");
            return rows_effected;
        }
    }
}
