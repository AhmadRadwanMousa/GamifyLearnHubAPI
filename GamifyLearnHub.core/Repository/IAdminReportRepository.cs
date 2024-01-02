using GamifyLearnHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
    public interface IAdminReportRepository
    {
        Task<List<AdminReportStudents>> GetAllStudentsReport();
        Task<List<AdminReportStudentsDetails>> GetAllStudentsReportDetails(int id);
        Task<List<AdminReportSections>> GetAllSectionsReport();
    }
}
