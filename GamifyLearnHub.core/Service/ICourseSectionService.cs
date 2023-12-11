using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
    public interface ICourseSectionService
    {
        Task<IEnumerable<Coursesection>> GetAllCourseSections();
        Task<Coursesection> GetCourseSectionById(decimal courseSectionId);
        Task<decimal> CreateCourseSection(Coursesection courseSection);
        Task<int> UpdateCourseSection(Coursesection courseSection);
        Task<int> DeleteCourseSection(decimal courseSectionId);
    }
}
