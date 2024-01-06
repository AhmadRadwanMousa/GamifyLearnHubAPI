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
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly IDbContext _dbContext;

        public TestimonialRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AcceptTestimonial(int id)
        {
            var p = new DynamicParameters();
            p.Add("Testimonial_Id", id, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RowsAffected", DbType.Int32, direction: ParameterDirection.Output);

            _dbContext.Connection.ExecuteAsync("Testimonial_Package.AcceptTestimonial", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("RowsAffected");
        }

        public async Task<int> CreateTestimonial(Testimonial testimonial)
        {
            var p = new DynamicParameters();
            p.Add("User_Id", testimonial.Userid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("User_Review", testimonial.Review, DbType.String, direction: ParameterDirection.Input);

            p.Add("CreatedId", DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.ExecuteAsync("Testimonial_Package.CreateTestimonial", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("CreatedId");
        }

        public async Task<int> DeleteTestimonial(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RowsAffected", DbType.Int32, direction: ParameterDirection.Output);

            _dbContext.Connection.ExecuteAsync("Testimonial_Package.DeleteTestimonial", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("RowsAffected");
        }


        public async Task<List<Testimonial>> GetAllTestimonials()
        {
            var result = await _dbContext.Connection.QueryAsync<Testimonial, User, Userlogin, Role, Testimonial>(
                "Testimonial_Package.GetAllTestimonials",
                (testimonial, user, userlogin, role) =>
                {
                    userlogin.Role = role;
                    user.Userlogins.Add(userlogin);
                    testimonial.User = user;


                    return testimonial;
                },
                splitOn: "userid,userloginid,roleid",
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }


        public async Task<Testimonial> GetTestimonialById(int id)
        {
        var p = new DynamicParameters();
        p.Add("Id", id, DbType.Int32, direction: ParameterDirection.Input);
        var result = await _dbContext.Connection.QueryAsync<Testimonial>("Testimonial_Package.GetTestimonialById", p, commandType: CommandType.StoredProcedure);
        return result.FirstOrDefault();
         }

        public async Task<int> RejectTestimonial(int id)
        {
            var p = new DynamicParameters();
            p.Add("Testimonial_Id", id, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RowsAffected", DbType.Int32, direction: ParameterDirection.Output);

            _dbContext.Connection.ExecuteAsync("Testimonial_Package.RejectTestimonial", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("RowsAffected");
        }

        public async Task<int> UpdateTestimonial(Testimonial testimonial)
        {
            var p = new DynamicParameters();
            p.Add("Testimonial_Id", testimonial.Testimonialid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("User_Id", testimonial.Userid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("User_Review", testimonial.Review, DbType.String, direction: ParameterDirection.Input);

            p.Add("RowsAffected", DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.ExecuteAsync("Testimonial_Package.UpdateTestimonial", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("RowsAffected");
        }

		public async Task<List<Testimonial>> GetTestimonialByUserId(int id)
		{
			var p = new DynamicParameters();
			p.Add("User_Id", id, DbType.Int32, direction: ParameterDirection.Input);
			var result = await _dbContext.Connection.QueryAsync<Testimonial>("Testimonial_Package.GetTestimonialByUserId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
		}
	}
}
