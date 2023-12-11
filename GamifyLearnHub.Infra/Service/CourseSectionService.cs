using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Service
{
    public class CourseSectionService : ICourseSectionService
    {
        private readonly ICourseSectionRepository _courseSectionRepository;

        public CourseSectionService(ICourseSectionRepository courseSectionRepository)
        {
            _courseSectionRepository = courseSectionRepository;
        }

        public Task<IEnumerable<Coursesection>> GetAllCourseSections()
        {
            return _courseSectionRepository.GetAllCourseSections();
        }

        public Task<Coursesection> GetCourseSectionById(decimal courseSectionId)
        {
            return _courseSectionRepository.GetCourseSectionById(courseSectionId);
        }

        public async Task<decimal> CreateCourseSection(Coursesection courseSection)
        {
            return await _courseSectionRepository.CreateCourseSection(courseSection);
        }

        public async Task<int> UpdateCourseSection(Coursesection courseSection)
        {
            return await _courseSectionRepository.UpdateCourseSection(courseSection);
        }

        public async Task<int> DeleteCourseSection(decimal courseSectionId)
        {
            return await _courseSectionRepository.DeleteCourseSection(courseSectionId);
        }
    }
}
