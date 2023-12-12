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
    public class AttendenceDetailService : IAttendenceDetailService
    {
        private readonly IAttendenceDetailRepository _attendenceDetailRepository;

        public AttendenceDetailService(IAttendenceDetailRepository attendenceDetailRepository)
        {
            _attendenceDetailRepository = attendenceDetailRepository;
        }

        public async Task<int> CreateAttendenceDetails(Attendencedetail attendencedetail)
        {
            return await _attendenceDetailRepository.CreateAttendenceDetails(attendencedetail);
        }

        public async Task<int> DeleteAttendenceDetails(int id)
        {
            return await _attendenceDetailRepository.DeleteAttendenceDetails(id);
        }

        public async Task<List<Attendencedetail>> GetAllAttendenceDetails()
        {
            return await _attendenceDetailRepository.GetAllAttendenceDetails();
        }

        public async Task<Attendencedetail> GetAttendenceDetailsById(int id)
        {
            return await _attendenceDetailRepository.GetAttendenceDetailsById(id);
        }

        public async Task<int> UpdateAttendenceDetails(Attendencedetail attendencedetail)
        {
            return await _attendenceDetailRepository.UpdateAttendenceDetails(attendencedetail);
        }
    }
}
