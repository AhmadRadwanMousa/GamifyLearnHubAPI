using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<int> CreateCourse(Course course)
        {
            var createdId = await _courseRepository.CreateCourse(course);
            return createdId;
        }

        public async Task<int> DeleteCourse(int id)
        {
            var rowsAffected = await _courseRepository.DeleteCourse(id);
            return rowsAffected;
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await _courseRepository.GetAllCourses();
        }

        public async Task<Course> GetCourseById(int id)
        {
            return await _courseRepository.GetCourseById(id);
        }

        public async Task<int> UpdateCourse(Course course)
        {
            var rowsAffected = await _courseRepository.UpdateCourse(course);
            return rowsAffected;
        }
    }
}
