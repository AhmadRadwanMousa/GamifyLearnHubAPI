using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMailService _mailService;
        
        public UserController(IUserService userService,IMailService mailService)
        {
            _userService = userService;
            _mailService = mailService; 
        }

        [HttpPost]
        public async Task<int> CreateUser([FromBody] UserDetails? userDetails)
        {
            MailData mailData = new MailData
            {
                EmailTo = "Subaruk898@gmail.com",
                EmailSubject = "Hello",
                EmailBody = $"<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n  <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Product Review</title>\r\n</head>\r\n<body style=\"font-family: Arial, sans-serif;\">\r\n\r\n    <h1>Hello ,</h1>\r\n\r\n    <p>Thank you for submitting a review for Product ID: .</p>\r\n\r\n    <h2>Your Review:</h2>\r\n        <p>We appreciate your feedback!</p>\r\n\r\n    <p>Best regards,</p>\r\n    <p>Ahmad Mousa</p>\r\n\r\n</body>\r\n</html>",
                EmailToName = "Ahmad Subaruk"
            };
            _mailService.SendEmail(mailData);
            return await _userService.CreateUser(userDetails);
        }
        [HttpDelete("{userId}")]
        public async Task<int>DeleteUser (int userId)
        {
           return await _userService.DeleteUser(userId);  
        }
        [HttpPut]
        //[Authorize]
        public async Task<int> UpdateUser([FromBody]UserDetails ?userDetails)
        {
            return await _userService.UpdateUser(userDetails);
        }
        [HttpPut]
        [Route("EditProfile")]
        public async Task<int> EditUserProfile([FromBody] UserDetails ?userDetails)
        {
            return await _userService.EditUserProfile(userDetails); 
        }
        [HttpGet]
        public async Task<List<User>> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }
        [HttpGet("{userId}")]
        public async Task<User> GetUserById(int userId)
        {
            var user =  await _userService.GetAllUsers();

            return user.Where(u => u.Userid == userId).FirstOrDefault();
        }
        [HttpGet]
        [Route("GetUnAcceptedUsers")]
        public async Task<List<User>> GetUnAcceptedUsers()
        {
           return await _userService.GetUnAcceptedUsers();    
        }
        [HttpPut]
        [Route("UpdatedUserStatus")]
        public async Task<int> UpdateUserStatus([FromForm]int userId, [FromForm] bool isAccepted)
        {
           return await _userService.UpdateUserStatus(userId, isAccepted);
        }

        [HttpGet]
        [Route("ReportsByUserId/{userId}/{programId}")]
        public async Task<List<ReportsUser>> ReportsByUserId(int userId, int programId)
        {
            return await _userService.ReportsByUserId(userId, programId);
        }

        [HttpGet]
        [Route("GetProgramsByUserId/{userId}")]
        public async Task<List<Core.Data.Program>> GetProgramsByUserId(int userId)
        {
            return await _userService.GetProgramsByUserId(userId);
        }

        [HttpPost]
        [Route("CreateInstructorDetails")]
        public async Task<int> CreateInstructorDetails([FromBody] Instructordetail instructordetail)
        {
            return await _userService.CreateInstructorDetails(instructordetail);
        }

        [HttpPut]
        [Route("UpdateInstructorDetails")]
        public async Task<int> UpdateInstructorDetails([FromBody] Instructordetail instructordetail)
        {
            return await _userService.UpdateInstructorDetails(instructordetail);
        }

        [HttpDelete]
        [Route("DeleteInstructorDetails/{instructorId}")]
        public async Task<int> DeleteInstructorDetails(decimal instructorId)
        {
            return await _userService.DeleteInstructorDetails(instructorId);
        }

        [HttpGet]
        [Route("GetInstructorDetailsById/{instructorId}")]
        public async Task<Instructordetail> GetInstructorDetailsById(decimal instructorId)
        {
            return await _userService.GetInstructorDetailsById(instructorId);
        }


    }
}
