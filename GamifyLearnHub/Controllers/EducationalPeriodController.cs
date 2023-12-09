using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Service;
using GamifyLearnHub.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EducationalPeriodController : ControllerBase
	{
		private readonly IEducationalPeriodService _educationalPeriodService;

        public EducationalPeriodController(IEducationalPeriodService educationalPeriodService)
        {
			this._educationalPeriodService = educationalPeriodService;
        }

		[HttpGet]
		[Route("GetAllEducationalPeriod")]
		public async Task<List<Educationalperiod>> GetAllEducationalperiod()
		{
			return await _educationalPeriodService.GetAllEducationalperiod();
		}
		[HttpPost]
		[Route("CreateEducationalperiod")]

		public async void CreateEducationalperiod(Educationalperiod educationalPeriod)
		{
			_educationalPeriodService.CreateEducationalperiod(educationalPeriod);
		}

		[HttpPut]
		[Route("UpdateEducationalperiod")]
		public async void UpdateEducationalperiod(Educationalperiod educationalPeriod)
		{
			_educationalPeriodService.UpdateEducationalperiod(educationalPeriod);
		}
		[HttpDelete("{id}")]
		public async void DeleteEducationalperiod(int id)
		{
			_educationalPeriodService.DeleteEducationalperiod(id);
		}
		[HttpGet]
		[Route("GetEducationalperiodById/{id}")]
		public async Task<Educationalperiod> GetEducationalperiodById(int id)
		{
			return await _educationalPeriodService.GetEducationalperiodById(id);
		}
	}

	
}
