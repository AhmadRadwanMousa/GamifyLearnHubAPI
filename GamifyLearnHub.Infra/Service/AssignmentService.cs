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
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepositroy;
        public AssignmentService(IAssignmentRepository assignmentRepositroy)
        {
            _assignmentRepositroy = assignmentRepositroy;
        }
        public async Task<int> CreateAssignment(Assignment assignment)
        {
       return  await _assignmentRepositroy.CreateAssignment(assignment); 
        }

        public Task<int> DeleteAssignment(int assignmentID)
        {
            return _assignmentRepositroy.DeleteAssignment(assignmentID);    
        }

        public async Task<List<Assignment>> GetAssignmentBySectionId(int sectionId)
        {
            return await _assignmentRepositroy.GetAssignmentBySectionId(sectionId);
        }

        public async Task<int> UpdateAssignment(Assignment assignment)
        {
           return await _assignmentRepositroy.UpdateAssignment(assignment); 

        }
    }
}
