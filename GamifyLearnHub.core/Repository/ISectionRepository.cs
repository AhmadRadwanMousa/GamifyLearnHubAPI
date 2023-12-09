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
        Task CreateSection(Section section);
        Task UpdateSection(Section section);
        Task DeleteSection(decimal sectionId);
    }
}
