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
    public class AssignmentSolutionService : IAssignmentSolutionService
    {
        private readonly IAssignmentSolutionRepository _assignmentSolutionRepository;
        public AssignmentSolutionService(IAssignmentSolutionRepository assignmentSolutionRepository)
        {
            _assignmentSolutionRepository = assignmentSolutionRepository;   
        }
        public async Task<int> CreateAssignmentSolution(Assignmentsolution assignmentsolution)
        {
          return await _assignmentSolutionRepository.CreateAssignmentSolution(assignmentsolution);  

        }

        public async Task<int> DeleteAssignmentSolution(int assignmentSolutionId)
        {
           return await _assignmentSolutionRepository.DeleteAssignmentSolution(assignmentSolutionId);   
        }

        public async Task<List<Assignmentsolution>> GetAssignmentSolutionByAssignmentId(int assignmentId)
        {
            return await _assignmentSolutionRepository.GetAssignmentSolutionByAssignmentId(assignmentId);
        }

        public async Task<int> UpdateAssignmentSolution(Assignmentsolution assignmentsolution)
        {
            return await _assignmentSolutionRepository.UpdateAssignmentSolution(assignmentsolution);
        }

        public async Task<int> UpdateAssignmentSolutionMark(AssignmentMark mark)
        {
            return await _assignmentSolutionRepository.UpdateAssignmentSolutionMark(mark);  
        }
    }
}
