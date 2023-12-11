using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
    public interface IAssignmentRepository
    {
        Task<int> CreateAssignment(Assignment assignment);
        Task<int> UpdateAssignment(Assignment assignment);
        Task<int> DeleteAssignment(int assignmentID);
        public Task<List<Assignment>> GetAssignmentBySectionId(int sectionId);
    }
}
