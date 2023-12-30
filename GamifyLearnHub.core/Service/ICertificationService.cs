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
        void InsertCertification(Certification certification);
        Task<List<Certification>> GetAllCertifications();
        void GoToNextCourse(List<CertificationUser> userPass);
        Task<int> UpdateCertificationStatus(int CourseSequenceId);

        Task<Certification> GetCertificationById(int id);
        Task<List<Certification>> GetCertificationByUserId(int id);


    }
}
