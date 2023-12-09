using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
    public interface IUserRepository
    {
        Task<int> CreateUser(UserDetails userDetails);
        Task<int> UpdateUser(UserDetails userDetails);
        Task <int>DeleteUser(int id);
        Task<User> GetUserById(int id);
        Task<List<User>> GetAllUsers();
        Task<int> EditUserProfile(UserDetails userDetails);

    }
}
