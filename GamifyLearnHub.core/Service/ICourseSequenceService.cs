using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
    public interface ICourseSequenceService
    {
        Task<List<Coursesequence>> GetAllCourseSequences();
        Task<Coursesequence> GetCourseSequenceById(int id);
        Task<int> CreateCourseSequence(Coursesequence coursesequence);
        Task<int> UpdateCourseSequence(Coursesequence coursesequence);
        Task<int> DeleteCourseSequence(int id);
    }
}
