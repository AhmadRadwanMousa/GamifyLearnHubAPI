using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
	public interface IEducationalPeriodService
	{
		Task<List<Educationalperiod>> GetAllEducationalperiod();
		void CreateEducationalperiod(Educationalperiod educationalPeriod);
		void DeleteEducationalperiod(int id);
		public void UpdateEducationalperiod(Educationalperiod educationalPeriod);
		Task<Educationalperiod> GetEducationalperiodById(int id);
	}
}
