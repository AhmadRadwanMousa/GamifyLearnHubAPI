using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
    public interface IAttendenceRepository
    {
        Task<List<Attendence>> GetAllAttendence();
        Task<Attendence> GetAttendenceById(int id);
        Task<int> CreateAttendence(Attendence attendence);
        Task<int> UpdateAttendence(Attendence attendence);
        Task<int> DeleteAttendence(int id);
    }
}
