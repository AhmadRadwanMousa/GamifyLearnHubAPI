using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
     public interface IAssignmentSolutionService
    {
        Task<int> CreateAssignmentSolution(Assignmentsolution assignmentsolution);
        Task<int> UpdateAssignmentSolution(Assignmentsolution assignmentsolution);
        Task<int> DeleteAssignmentSolution(int assignmentSolutionId);
          Task<List<Assignmentsolution>> GetAssignmentSolutionByAssignmentId(int assignmentId);
        Task<int> UpdateAssignmentSolutionMark(AssignmentMark mark);
        Task<Assignmentsolution> GetAssignmentSolutionByUserId(int assignmentId, int userId);

    }
}
