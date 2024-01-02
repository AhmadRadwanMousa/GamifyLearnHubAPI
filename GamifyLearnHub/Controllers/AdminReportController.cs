using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminReportController : ControllerBase
    {
        private readonly IAdminReportService _adminReportService;
        public AdminReportController(IAdminReportService adminReportService)
        {
            _adminReportService = adminReportService;
        }

        [HttpGet("GetAllStudentsReport")]
        public async Task<List<AdminReportStudents>> GetAllStudentsReport() 
        {
            return await _adminReportService.GetAllStudentsReport();
        }

        [HttpGet("GetAllStudentsDetailsReport/{id}")]
        public async Task<List<AdminReportStudentsDetails>> GetAllStudentsDetailsReport(int id)
        {
            return await _adminReportService.GetAllStudentsReportDetails(id);
        }

        [HttpGet("GetAllSectionsReport")]
        public async Task<List<AdminReportSections>> GetAllSectionsReport()
        {
            return await _adminReportService.GetAllSectionsReport();
        }
    }
}
