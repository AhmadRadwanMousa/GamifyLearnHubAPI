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
		Task<int> CreateEducationalperiod(Educationalperiod educationalPeriod);
		Task<int> DeleteEducationalperiod(int id);
		Task<int> UpdateEducationalperiod(Educationalperiod educationalPeriod);
		Task<Educationalperiod> GetEducationalperiodById(int id);
	}
}
