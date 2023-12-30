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

	public class ReportService : IReportService
	{
		private readonly IReportRepository _reportRepository;
		public ReportService(IReportRepository reportRepository)
		{
			_reportRepository = reportRepository;
		}

		

		public async Task<List<InstructorReport>> GetAllReportsByInstructorId(int Id)
		{
			return await _reportRepository.GetAllReportsByInstructorId(Id);
		}
	}
}
