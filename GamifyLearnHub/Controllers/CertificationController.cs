using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Service;
using GamifyLearnHub.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificationController : ControllerBase
    {
        private readonly ICertificationService _certificationService;
        public CertificationController(ICertificationService certificationService)
        {
            _certificationService = certificationService;
        }



        [HttpGet]
        public async Task<List<Certification>> GetAllCertifications()
        {
            return await _certificationService.GetAllCertifications();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<Certification> GetCertificationById(int id)
        {
            return await _certificationService.GetCertificationById(id);
        }

        [HttpGet]
        [Route("GetByUserId/{id}")]
        public async Task<List<Certification>> GetCertificationByUserId(int id)
        {
            return await _certificationService.GetCertificationByUserId(id);
        }

        [HttpGet]
        [Route("PassUser/{CourseSequence}")]
        public async Task<IActionResult> GetAllUsersPass(int CourseSequence)
        {
            var (UsersPass, Date_End) = await _certificationService.GetAllUsersPass(CourseSequence);

            if (Date_End == 1)
            {
                 _certificationService.InsertCertification(UsersPass);
                return Ok();
            }
            else
            {
                return BadRequest("End Date Not Yet.");
            }
        }

      

    }
}
