using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Service
{
    public class LectureService : ILectureService
    {
        private readonly ILectureRepository _lectureRepository;

        public LectureService(ILectureRepository lectureRepository)
        {
            _lectureRepository = lectureRepository;
        }

        public Task<IEnumerable<Lecture>> GetAllLectures()
        {
            return _lectureRepository.GetAllLectures();
        }

        public Task<Lecture> GetLectureById(decimal lectureId)
        {
            return _lectureRepository.GetLectureById(lectureId);
        }

        public async Task<decimal> CreateLecture(Lecture lecture)
        {
            return await _lectureRepository.CreateLecture(lecture);
        }

        public async Task<int> UpdateLecture(Lecture lecture)
        {
            return await _lectureRepository.UpdateLecture(lecture);
        }

        public async Task<int> DeleteLecture(decimal lectureId)
        {
            return await _lectureRepository.DeleteLecture(lectureId);
        }

        public async Task<List<LecturesPerCourse>> GetLecturesCountByCourse(int userId, int programId)
        {
           return await _lectureRepository.GetLecturesCountByCourse(userId, programId); 
        }
    }
}
