﻿using GamifyLearnHub.Attributes;
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
        [CheckClaims("roleId", "1")]
        public async Task<List<Educationalperiod>> GetAllEducationalperiod()
		{
			return await _educationalPeriodService.GetAllEducationalperiod();
		}
		[HttpPost]
		[Route("CreateEducationalperiod")]
        [CheckClaims("roleId", "1")]
        public async Task<int> CreateEducationalperiod([FromBody] Educationalperiod educationalPeriod)
		{
			return await _educationalPeriodService.CreateEducationalperiod(educationalPeriod);
		}
		[HttpPut]
		[Route("UpdateEducationalperiod")]
        [CheckClaims("roleId", "1")]
        public async Task<int> UpdateEducationalperiod([FromBody]Educationalperiod educationalPeriod)
		{
			return await _educationalPeriodService.UpdateEducationalperiod(educationalPeriod);
		}
		[HttpDelete("{id}")]
        [CheckClaims("roleId", "1")]
        public async Task<int> DeleteEducationalperiod(int id)
		{
			return await _educationalPeriodService.DeleteEducationalperiod(id);
		}
		[HttpGet]
		[Route("GetEducationalperiodById/{id}")]
        [CheckClaims("roleId", "1")]
        public async Task<Educationalperiod> GetEducationalperiodById(int id)
		{
			return await _educationalPeriodService.GetEducationalperiodById(id);
		}
	}

	
}
