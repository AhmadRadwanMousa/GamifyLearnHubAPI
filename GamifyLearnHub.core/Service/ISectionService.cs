using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
    public interface ISectionService
    {
        Task<IEnumerable<Section>> GetAllSections();
        Task<Section> GetSectionById(decimal sectionId);
        Task CreateSection(Section section);
        Task UpdateSection(Section section);
        Task DeleteSection(decimal sectionId);
    }
}
