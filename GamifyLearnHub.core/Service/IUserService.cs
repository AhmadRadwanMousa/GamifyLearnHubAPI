using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
    public interface IUserService
    {
        Task<int> CreateUser(UserDetails userDetails);
        Task<int> UpdateUser(UserDetails userDetails);
        Task<int> EditUserProfile(UserDetails userDetails);
        Task<int> DeleteUser(int id);
        Task<User> GetUserById(int id);
        Task<List<User>> GetAllUsers();

    }
}
