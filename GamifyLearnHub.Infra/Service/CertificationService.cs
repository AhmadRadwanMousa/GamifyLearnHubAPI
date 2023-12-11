using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using GamifyLearnHub.Infra.Repositroy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Service
{
    public class CertificationService : ICertificationService
    {
        private readonly ICertificationRepository _certificationRepository;
        public CertificationService(ICertificationRepository certificationRepository)
        {
            _certificationRepository = certificationRepository;
        }

        public async Task<List<Certification>> GetAllCertifications()
        {
            return await _certificationRepository.GetAllCertifications();

        }

        public async Task<(List<CertificationUser>, int)> GetAllUsersPass(int CourseSequence)
        {
            var ( UsersPass , Date_End) = await _certificationRepository.GetAllUsersPass(CourseSequence);
            return (UsersPass , Date_End);
        }

        public async Task<Certification> GetCertificationById(int id)
        {
            return await _certificationRepository.GetCertificationById(id);
        }

        public async Task<List<Certification>> GetCertificationByUserId(int id)
        {
            return await _certificationRepository.GetCertificationByUserId(id);
        }

        public async void InsertCertification(List<CertificationUser> certificationUsers)
        {
            for (int i = 0; i < certificationUsers.Count; i++)
            {
                Certification certification = new Certification();
                certification.Certificationimage = "xx.png";
                certification.Userid = certificationUsers[i].Userid;
                certification.Dateearned = DateTime.Today;
                certification.Coursesequenceid = certificationUsers[i].Coursesequenceid;
                _certificationRepository.InsertCertification(certification);
            }
        }
    }
}
