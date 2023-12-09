
using System.Threading.Tasks;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;

namespace GamifyLearnHup.Infra.Service
{
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository _sectionRepository;

        public SectionService(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public async Task<IEnumerable<Section>> GetAllSections()
        {
            return await _sectionRepository.GetAllSections();
        }

        public Task<Section> GetSectionById(decimal sectionId)
        {
            return _sectionRepository.GetSectionById(sectionId);
        }

        public Task CreateSection(Section section)
        {
            return _sectionRepository.CreateSection(section);
        }

        public Task UpdateSection(Section section)
        {
            return _sectionRepository.UpdateSection(section);
        }

        public Task DeleteSection(decimal sectionId)
        {
            return _sectionRepository.DeleteSection(sectionId);
        }
    }
}
