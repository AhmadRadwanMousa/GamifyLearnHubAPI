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
    public class AdminReportService : IAdminReportService
    {
        private readonly IAdminReportRepository _adminReportRepository;
        public AdminReportService(IAdminReportRepository adminReportRepository)
        {
            _adminReportRepository = adminReportRepository;
        }

        public async Task<List<AdminReportSections>> GetAllSectionsReport()
        {
            return await _adminReportRepository.GetAllSectionsReport();
        }

        public async Task<List<AdminReportStudents>> GetAllStudentsReport()
        {
            return await _adminReportRepository.GetAllStudentsReport();
        }

        public async Task<List<AdminReportStudentsDetails>> GetAllStudentsReportDetails(int id)
        {
            return await _adminReportRepository.GetAllStudentsReportDetails(id);
        }
    }
}
