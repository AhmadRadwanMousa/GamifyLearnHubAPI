using Dapper;
using GamifyLearnHub.Core.Common;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Repositroy
{
	public class ContactUsRepository : IContactUsRepository
	{
		private readonly IDbContext _dbContext;

		public ContactUsRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<int> CreateContactUs(Contactu contact)
		{
			var p = new DynamicParameters();
            p.Add("Name", contact.Name, dbType:DbType.String, direction:ParameterDirection.Input);
            p.Add("PhoneNumber", contact.Phonenumber, dbType:DbType.Int32, direction:ParameterDirection.Input);
			p.Add("Subject", contact.Subject, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("Message", contact.Message, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("Email", contact.Email, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("MessageReceived", contact.Messagereceived, dbType: DbType.Date, direction: ParameterDirection.Input);
			p.Add("created_id", dbType:DbType.Int32, direction:ParameterDirection.Output);
            p.Add("rows_affected", dbType:DbType.Int32, direction:ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("Contact_Package.CreateContact", p,commandType:CommandType.StoredProcedure);

            return p.Get<int>("created_id");
		}

		public async Task<int> DeleteContactUs(int id)
		{
			var p = new DynamicParameters();
			p.Add("ContactId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("deleted_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
			p.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);
			await _dbContext.Connection.ExecuteAsync("Contact_Package.DeleteContact", p, commandType: CommandType.StoredProcedure);
			return p.Get<int>("rows_affected");
		}

		public async Task<List<Contactu>> GetAllContactUs()
		{
			var result = await _dbContext.Connection.QueryAsync<Contactu>("Contact_Package.GetAllContacts", commandType: CommandType.StoredProcedure);
			return result.ToList();
		}
	}
}
