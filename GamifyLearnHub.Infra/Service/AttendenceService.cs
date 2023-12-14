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
    public class AttendenceService : IAttendenceService
    {
        private readonly IAttendenceRepository _attendenceRepository;

        public AttendenceService(IAttendenceRepository attendenceRepository)
        {
            _attendenceRepository = attendenceRepository;
        }

        public async Task<int> CreateAttendence(Attendence attendence)
        {
            return await _attendenceRepository.CreateAttendence(attendence);
        }

        public async Task<int> DeleteAttendence(int id)
        {
            return await _attendenceRepository.DeleteAttendence(id);
        }

        public async Task<List<Attendence>> GetAllAttendence()
        {
            return await _attendenceRepository.GetAllAttendence();
        }

        public async Task<Attendence> GetAttendenceById(int id)
        {
            return await _attendenceRepository.GetAttendenceById(id);
        }

        public async Task<int> UpdateAttendence(Attendence attendence)
        {
            return await _attendenceRepository.UpdateAttendence(attendence);
        }
    }
}
