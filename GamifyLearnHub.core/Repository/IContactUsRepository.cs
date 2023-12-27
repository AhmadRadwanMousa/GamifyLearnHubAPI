using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
	public interface IContactUsRepository
	{
		Task<List<Contactu>> GetAllContactUs();
		Task<int> DeleteContactUs(int id);
		Task<int> CreateContactUs(Contactu contact);
	}
}
