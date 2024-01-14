using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository; 
        }
        public async Task<int> CreateUser(UserDetails userDetails)
        {
            return await _userRepository.CreateUser(userDetails);  
        }

        public async Task <int> DeleteUser(int id)
        {
            return await _userRepository.DeleteUser(id);
        }

        public async Task<int> EditUserProfile(UserDetails userDetails)
        {
            return await _userRepository.EditUserProfile(userDetails);   
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers(); 
        }

        public async Task<List<Program>> GetProgramsByUserId(int userId)
        {
            return await _userRepository.GetProgramsByUserId(userId);
        }

        public async Task<List<User>> GetUnAcceptedUsers()
        {
           return await _userRepository.GetUnAcceptedUsers();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);   
        }

        public async Task<List<ReportsUser>> ReportsByUserId(int userId, int programId)
        {
            return await _userRepository.ReportsByUserId(userId, programId);
        }


        public async Task<int> UpdateUser(UserDetails? userDetails)
        {
          return await _userRepository.UpdateUser(userDetails);    
        }

        public async Task<int> UpdateUserStatus(int userId, int isAccepted)
        {
            return await _userRepository.UpdateUserStatus(userId, isAccepted);  
        }

        public async Task<int> CreateInstructorDetails(Instructordetail instructordetail)
        {
            return await _userRepository.CreateInstructorDetails(instructordetail);
        }

        public async Task<int> UpdateInstructorDetails(Instructordetail instructordetail)
        {
            return await _userRepository.UpdateInstructorDetails(instructordetail);
        }

        public async Task<int> DeleteInstructorDetails(decimal instructorId)
        {
            return await _userRepository.DeleteInstructorDetails(instructorId);
        }

        public async Task<Instructordetail> GetInstructorDetailsById(decimal instructorId)
        {
            return await _userRepository.GetInstructorDetailsById(instructorId);
        }
    }
}
