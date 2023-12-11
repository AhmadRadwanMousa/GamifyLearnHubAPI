using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
    public interface ICertificationService
    {
        Task<(List<CertificationUser>, int)> GetAllUsersPass(int CourseSequence);
        void InsertCertification(List<CertificationUser> usersections);
        Task<List<Certification>> GetAllCertifications();

        Task<Certification> GetCertificationById(int id);
        Task<List<Certification>> GetCertificationByUserId(int id);


    }
}
