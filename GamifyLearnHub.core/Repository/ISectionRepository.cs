using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using GamifyLearnHub.Core.Data;

namespace GamifyLearnHub.Core.Repository
{
    public interface ISectionRepository
    {
        Task<IEnumerable<Section>> GetAllSections();
        Task<Section> GetSectionById(decimal sectionId);
        Task<List<Section>> GetSectionByCourseId(decimal courseId);
        Task<decimal> CreateSection(Section section);
        Task<int> UpdateSection(decimal sectionId, Section section);
        Task<int> DeleteSection(decimal sectionId);

        Task<IEnumerable<User>> GetAllUsersWithRoleId2();

    }
}
