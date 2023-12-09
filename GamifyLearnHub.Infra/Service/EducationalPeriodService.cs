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
        public void CreateEducationalperiod(Educationalperiod educationalPeriod)
		{
			_educationalPeriodRepository.CreateEducationalperiod(educationalPeriod);
		}

		public void DeleteEducationalperiod(int id)
		{
			_educationalPeriodRepository.DeleteEducationalperiod(id);
		}

		public async Task<List<Educationalperiod>> GetAllEducationalperiod()
		{
			return await _educationalPeriodRepository.GetAllEducationalperiod();
		}

		public async Task<Educationalperiod> GetEducationalperiodById(int id)
		{
			return await _educationalPeriodRepository.GetEducationalperiodById(id);
		}

		public void UpdateEducationalperiod(Educationalperiod educationalPeriod)
		{
			_educationalPeriodRepository.UpdateEducationalperiod(educationalPeriod);
		}
	}
}
