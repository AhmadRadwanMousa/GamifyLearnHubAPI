﻿using GamifyLearnHub.Core.Data;
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
        Task<List<Section>> GetSectionByCourseId(decimal courseId);
        Task<decimal> CreateSection(Section section);
        Task<int> UpdateSection(decimal sectionId, Section section);
        Task<int> DeleteSection(decimal sectionId);
    }
}
