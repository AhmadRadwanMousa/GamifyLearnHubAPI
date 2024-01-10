using GamifyLearnHub.Attributes;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReportController : ControllerBase
	{
		private readonly IReportService _reportService;

		public ReportController(IReportService reportService)
		{
			_reportService = reportService;
		}


		[HttpGet("GetSectionReport/{id}")]
        [CheckClaims("roleId", "2")]
        public async Task<List<InstructorReport>> GetAllReportsByInstructorId(int id)
		{
			return await _reportService.GetAllReportsByInstructorId(id);
		}

		
	}
}

