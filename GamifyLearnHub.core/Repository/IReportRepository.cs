using GamifyLearnHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
	public interface IReportRepository
	{ 
		Task<List<InstructorReport>> GetAllReportsByInstructorId(int Id);
	}
}
