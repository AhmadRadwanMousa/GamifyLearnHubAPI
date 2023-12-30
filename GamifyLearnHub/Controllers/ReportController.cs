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


		[HttpGet]
		public async Task<List<InstructorReport>> GetAllReportsByInstructorId(int Id)
		{
			return await _reportService.GetAllReportsByInstructorId(Id);
		}

		
	}
}

