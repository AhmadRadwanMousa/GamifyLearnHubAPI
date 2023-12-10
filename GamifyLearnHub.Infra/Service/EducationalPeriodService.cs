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
	public class EducationalPeriodService : IEducationalPeriodService
	{
		private readonly IEducationalPeriodRepository _educationalPeriodRepository;
        public EducationalPeriodService(IEducationalPeriodRepository educationalPeriodRepository)
        {
            this._educationalPeriodRepository = educationalPeriodRepository;
        }
        public async Task<int> CreateEducationalperiod(Educationalperiod educationalPeriod)
		{
			return await _educationalPeriodRepository.CreateEducationalperiod(educationalPeriod);
		}

		public async Task<int> DeleteEducationalperiod(int id)
		{
			return await _educationalPeriodRepository.DeleteEducationalperiod(id);
		}

		public async Task<List<Educationalperiod>> GetAllEducationalperiod()
		{
			return await _educationalPeriodRepository.GetAllEducationalperiod();
		}

		public async Task<Educationalperiod> GetEducationalperiodById(int id)
		{
			return await _educationalPeriodRepository.GetEducationalperiodById(id);
		}

		public async Task<int> UpdateEducationalperiod(Educationalperiod educationalPeriod)
		{
			return await _educationalPeriodRepository.UpdateEducationalperiod(educationalPeriod);
		}
	}
}
