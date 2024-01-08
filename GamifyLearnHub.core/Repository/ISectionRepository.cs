using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;

namespace GamifyLearnHub.Core.Repository
{
    public interface ISectionRepository
    {
        Task<IEnumerable<Section>> GetAllSections();
        Task<Section> GetSectionById(decimal sectionId);
        Task<List<Section>> GetSectionByCourseId(decimal courseId);
        Task<List<Section>> GetAllSectionsByCourseSequenceId(int coursesequenceId);
        Task<List<Section>> GetAllSectionsByUserId(int userId);
        Task<decimal> CreateSection(Section section);
        Task<int> UpdateSection(decimal sectionId, Section section);
        Task<int> DeleteSection(decimal sectionId);
        Task<List<Section>> GetSectionByInstructorId(int instructorId);
        Task<IEnumerable<User>> GetAllUsersWithRoleId2();

        Task<Section>GetSectionByUserIdAndCourseSequenceId(int userId, int coursesequenceId);
        Task<List<Section>> GetSectionsByUserId(int userId);

        Task<List<Top3BySectionId>> Top3BySectionId(int sectionId);

    }
}
