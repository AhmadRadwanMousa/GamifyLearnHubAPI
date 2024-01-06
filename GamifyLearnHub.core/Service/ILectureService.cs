using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
    public interface ILectureService
    {
        Task<IEnumerable<Lecture>> GetAllLectures();
        Task<Lecture> GetLectureById(decimal lectureId);
        Task<decimal> CreateLecture(Lecture lecture);
        Task<int> UpdateLecture(Lecture lecture);
        Task<int> DeleteLecture(decimal lectureId);
        Task<List<LecturesPerCourse>> GetLecturesCountByCourse(int userId, int programId);

    }
}
