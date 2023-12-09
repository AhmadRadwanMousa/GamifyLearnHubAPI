using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
    public interface IRoleRepository
    {
        Task<int> CreateRole(string roleName);
        Task<int> DeleteRole(int roleId);
        Task<int> UpdateRole(Role role);
        Task<Role>GetRoleById(int roleId);  
        Task<List<Role>> GetAllRoles(); 

    }
}
