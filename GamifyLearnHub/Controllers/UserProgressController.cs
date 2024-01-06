using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamifyLearnHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProgressController : ControllerBase
    {
        private readonly IUserProgressService _userProgressService;

        public UserProgressController(IUserProgressService userProgressService)
        {
            _userProgressService = userProgressService;
        }

        [HttpGet]
        public async Task<IEnumerable<Userprogress>> GetAllUserProgress()
        {
            return await _userProgressService.GetAllUserProgress();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Userprogress>> GetUserProgressById(decimal id)
        {
            var userProgress = await _userProgressService.GetUserProgressById(id);
            if (userProgress == null)
            {
                return NotFound();
            }
            return userProgress;
        }

        [HttpPost]
        public async Task<ActionResult<decimal>> CreateUserProgress(Userprogress userProgress)
        {
            decimal createdId = await _userProgressService.CreateUserProgress(userProgress);
            return CreatedAtAction(nameof(GetUserProgressById), new { id = createdId }, createdId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserProgress(decimal id, Userprogress userProgress)
        {
            try
            {
                int affectedRows = await _userProgressService.UpdateUserProgress(id, userProgress.Userid ?? 0, userProgress.Lectureid ?? 0);
                return affectedRows > 0
                    ? Ok(new { affectedRows })
                    : NotFound(new { affectedRows });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserProgress(decimal id)
        {
            try
            {
                int affectedRows = await _userProgressService.DeleteUserProgress(id);
                return Ok(new { affectedRows });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
        [HttpGet]
        [Route("GetAllUserProgressPerSection/{userId}/{sectionId}")]
        public async Task<List<Userprogress>>GetUserProgressBySectionAndUserId(int userId,int sectionId)
        {
            return await _userProgressService.GetUserProgressBySectionAndUserId(userId, sectionId); 
        }
        [HttpGet]
        [Route("GetProgressPerCourse/{userId}/{programId}")]
        public async Task<List<UserProgressPerCourse>>GetProgressPerCourse(int userId,int programId)
        {
            return await _userProgressService.GetProgressPerCourse(userId, programId);  
        } 
    }
}
