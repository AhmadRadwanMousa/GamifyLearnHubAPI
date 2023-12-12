using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
    public interface IAttendenceDetailService
    {
        Task<List<Attendencedetail>> GetAllAttendenceDetails();
        Task<Attendencedetail> GetAttendenceDetailsById(int id);
        Task<int> CreateAttendenceDetails(Attendencedetail attendencedetail);
        Task<int> UpdateAttendenceDetails(Attendencedetail attendencedetail);
        Task<int> DeleteAttendenceDetails(int id);
    }
}
