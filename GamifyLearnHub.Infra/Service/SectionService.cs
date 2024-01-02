using System.Collections.Generic;
using System.Threading.Tasks;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;

namespace GamifyLearnHub.Infra.Service
{
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository _sectionRepository;

        public SectionService(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public async Task<IEnumerable<Section>> GetAllSections()
        {
            return await _sectionRepository.GetAllSections();
        }

        public Task<Section> GetSectionById(decimal sectionId)
        {
            return _sectionRepository.GetSectionById(sectionId);
        }

        public async Task<decimal> CreateSection(Section section)
        {
            return await _sectionRepository.CreateSection(section);
        }

        public async Task<int> UpdateSection(decimal sectionId, Section section)
        {
            int rowsAffected = await _sectionRepository.UpdateSection(sectionId, section);
            return rowsAffected;
        }

        public async Task<int> DeleteSection(decimal sectionId)
        {
            int rowsAffected = await _sectionRepository.DeleteSection(sectionId);
            return rowsAffected;
        }

        public async Task<List<Section>> GetSectionByCourseId(decimal courseId)
        {
            return await _sectionRepository.GetSectionByCourseId(courseId);
        }

        public async Task<IEnumerable<User>> GetAllUsersWithRoleId2()
        {
            return await _sectionRepository.GetAllUsersWithRoleId2();
        }

        public async Task<List<Section>> GetAllSectionsByCourseSequenceId(int coursesequenceId)
        {
            return await _sectionRepository.GetAllSectionsByCourseSequenceId(coursesequenceId);
        }

        public async Task<List<Section>> GetAllSectionsByUserId(int userId)
        {
            return await _sectionRepository.GetAllSectionsByUserId(userId);
        }

        public async Task<List<Section>> GetSectionByInstructorId(int instructorId)
        {
            return await _sectionRepository.GetSectionByInstructorId(instructorId);
        }

        public async Task<Section> GetSectionByUserIdAndCourseSequenceId(int userId, int coursesequenceId)
        {
            return await _sectionRepository.GetSectionByUserIdAndCourseSequenceId(userId, coursesequenceId);
        }
    }
}
