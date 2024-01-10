﻿using GamifyLearnHub.Attributes;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Service;
using GamifyLearnHub.Infra.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyLearnHub.Controllers
{
	
	[Route("api/[controller]")]
	[ApiController]
	public class ContactUsController : ControllerBase
	{
	private readonly IContactUsService _contactService;

        public ContactUsController(IContactUsService contactService)
        {
            _contactService = contactService;
        }

		[HttpGet("GetAllContacts")]
        [CheckClaims("roleId", "1")]
        public async Task<List<Contactu>> GetAllContactUs()
		{
			return await _contactService.GetAllContactUs();
		}

		[HttpDelete("{id}")]
        [CheckClaims("roleId", "1")]
        public async Task<int> DeleteContactUs(int id)
		{
			return await _contactService.DeleteContactUs(id);
		}
		[HttpPost]
		[AllowAnonymous]
		public async Task<int> CreateContactUs(Contactu contact)
		{
			return await _contactService.CreateContactUs(contact);
		}
	}
}
