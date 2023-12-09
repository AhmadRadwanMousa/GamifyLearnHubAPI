using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Service
{
   
    
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<int> CreateRole(string roleName)
        {
           return await _roleRepository.CreateRole(roleName);
        }

        public async Task<int> DeleteRole(int roleId)
        {
           return await _roleRepository.DeleteRole(roleId);   
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await _roleRepository.GetAllRoles();
        }

        public async Task<Role> GetRoleById(int roleId)
        {
           return await _roleRepository.GetRoleById(roleId);
        }

        public async Task<int> UpdateRole(Role role)
        {
            return await _roleRepository.UpdateRole(role);
        }
    }
}
