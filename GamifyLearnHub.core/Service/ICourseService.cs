using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllCourses();
        Task<Course> GetCourseById(int id);
        Task<int> CreateCourse(Course course);
        Task<int> UpdateCourse(Course course);
        Task<int> DeleteCourse(int id);
    }
}
