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
    public class AssignmentSolutionDetailsService : IAssignmentSolutionDetailsService
    {
        private readonly IAssignmentSolutionDetailsRepository _assignmentSolutionDetailsRepository;
        public AssignmentSolutionDetailsService(IAssignmentSolutionDetailsRepository assignmentSolutionDetailsRepository)
        {
            _assignmentSolutionDetailsRepository=assignmentSolutionDetailsRepository;   
        }
        public async Task<int> CreateAssignmentSolutionDetails(Assignmentsolutiondetail assignmentsolutiondetail)
        {
            return await _assignmentSolutionDetailsRepository.CreateAssignmentSolutionDetails(assignmentsolutiondetail);    
        }

        public async Task<int> DeleteAssignmentSolutionDetails(int assignmentSolutionDetailsId)
        {
            return await _assignmentSolutionDetailsRepository.DeleteAssignmentSolutionDetails(assignmentSolutionDetailsId);
        }

        public async Task<Assignmentsolutiondetail> GetAssignmentsolutiondetailById(int assignmentSolutionDetailsId)
        {
            return await _assignmentSolutionDetailsRepository.GetAssignmentsolutiondetailById(assignmentSolutionDetailsId);
        }

        public async Task<List<Assignmentsolutiondetail>> GetAssignmentSolutionDetailsByAssignmentId(int assignmentId)
        {
           return await _assignmentSolutionDetailsRepository.GetAssignmentSolutionDetailsByAssignmentId(assignmentId);
        }

        public async Task<int> UpdateAssignmentSolutionDetails(Assignmentsolutiondetail assignmentsolutiondetail)
        {
            return await _assignmentSolutionDetailsRepository.UpdateAssignmentSolutionDetails(assignmentsolutiondetail);    
        }
    }
}
