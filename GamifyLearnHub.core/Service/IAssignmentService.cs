using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
    public interface IAssignmentService
    {
        Task<int> CreateAssignment(Assignment assignment);
        Task<int> UpdateAssignment(Assignment assignment);
        Task<int> DeleteAssignment(int assignmentID);
        public Task<List<Assignment>> GetAssignmentBySectionId(int sectionId);

    }
}
