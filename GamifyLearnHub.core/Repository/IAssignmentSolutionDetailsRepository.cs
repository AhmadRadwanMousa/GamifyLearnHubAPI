using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
    public interface IAssignmentSolutionDetailsRepository
    {
        Task<int> CreateAssignmentSolutionDetails(Assignmentsolutiondetail assignmentsolutiondetail);
        Task<int> UpdateAssignmentSolutionDetails(Assignmentsolutiondetail assignmentsolutiondetail);
        Task<int> DeleteAssignmentSolutionDetails(int assignmentSolutionDetailsId);
        Task<List<Assignmentsolutiondetail>> GetAssignmentSolutionDetailsByAssignmentId(int assignmentId);
        Task<Assignmentsolutiondetail> GetAssignmentsolutiondetailById(int assignmentSolutionDetailsId);

    }
}
