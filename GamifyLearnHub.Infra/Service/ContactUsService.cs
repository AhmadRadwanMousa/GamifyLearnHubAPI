using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using GamifyLearnHub.Infra.Repositroy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Service
{
	public class ContactUsService : IContactUsService
	{
		private readonly IContactUsRepository _contactRepository;

		public ContactUsService(IContactUsRepository contactRepository)
		{
			_contactRepository = contactRepository;
		}

		public async Task<int> CreateContactUs(Contactu contact)
		{
			return await _contactRepository.CreateContactUs(contact);
		}

		public async Task<int> DeleteContactUs(int id)
		{
			return await _contactRepository.DeleteContactUs(id);
		}

		public async Task<List<Contactu>> GetAllContactUs()
		{
			return await _contactRepository.GetAllContactUs();
		}
	}
}
