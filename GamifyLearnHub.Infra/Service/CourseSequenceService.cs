using GamifyLearnHub.Core.Data;
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
    public class CourseSequenceService : ICourseSequenceService
    {
        private readonly ICourseSequenceRepository _courseSequenceRepository;
        public CourseSequenceService(ICourseSequenceRepository courseSequenceRepository)
        {
            _courseSequenceRepository = courseSequenceRepository;
        }

        public async Task<int> CreateCourseSequence(Coursesequence coursesequence)
        {
            var createdId = await _courseSequenceRepository.CreateCourseSequence(coursesequence);
            return createdId;
        }

        public async Task<int> DeleteCourseSequence(int id)
        {
            var rowsAffected = await _courseSequenceRepository.DeleteCourseSequence(id);
            return rowsAffected;
        }

        public async Task<List<Coursesequence>> GetAllCourseSequences()
        {
            return await _courseSequenceRepository.GetAllCourseSequences();
        }

        public async Task<Coursesequence> GetCourseSequenceById(int id)
        {
            return await _courseSequenceRepository.GetCourseSequenceById(id);
        }

        public async Task<int> UpdateCourseSequence(Coursesequence coursesequence)
        {
            var rowsAffected = await _courseSequenceRepository.UpdateCourseSequence(coursesequence);
            return rowsAffected;
        }
    }
}
