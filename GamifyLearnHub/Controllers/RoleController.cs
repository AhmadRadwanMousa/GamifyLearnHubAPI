using GamifyLearnHub.Attributes;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService; 
        }
        [HttpGet]
        public async Task<List<Role>> GetAllRoles()
        {
            return await _roleService.GetAllRoles();
        }
        [HttpGet("{roleId}")]
        public async Task<Role> GetRoleById(int roleId)
        {
            return await _roleService.GetRoleById(roleId);
        }
        [HttpPost]
        [CheckClaims("roleId", "1")]
        public async Task<int> CreateRole ([FromBody] Role role)
        {
            return await _roleService.CreateRole(role); 
        }
        [HttpDelete("{roleId}")]
        [CheckClaims("roleId", "1")]
        public async Task<int> DeleteRole(int roleId)
        {
            return await _roleService.DeleteRole(roleId);
        }
        [HttpPut]
        [CheckClaims("roleId", "1")]
        public async Task<int> UpdateRole([FromBody] Role role)
        {
            return await _roleService.UpdateRole(role);
        }
     

    }
}
