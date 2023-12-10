using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
    public interface ICertificationRepository
    {
        Task<(List<CertificationUser>, int)> GetAllUsersPass(int CourseSequence);
        void InsertCertification(Certification usersections);

    }
}
