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

        public async void GoToNextCourse(List<CertificationUser> userPass)
        {
            var groupedUsers = userPass.GroupBy(u => u.Sectionid);
            foreach (var group in groupedUsers)
            {
                int prevSectionId = (int)group.Key;
                int numberOfUsersPass = group.Count();
                 var newSectionId = await _certificationRepository.CreateNewSection(prevSectionId , numberOfUsersPass);
                int sectionId = Convert.ToInt32(newSectionId);
                foreach (var user in group)
                {
                    int userId = Convert.ToInt32(user.Userid);
                    var numberAffect = await _certificationRepository.CreateUserSection( sectionId, userId);
                   
                }

            }
          
        }

        public async void InsertCertification(Certification certification)
        {
            _certificationRepository.InsertCertification(certification);

        }

        public async Task<int> UpdateCertificationStatus(int CourseSequenceId)
        {
          return await  _certificationRepository.UpdateCertificationStatus(CourseSequenceId);
        }
    }
}
