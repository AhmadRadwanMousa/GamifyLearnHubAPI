using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
    public interface ITestimonialRepository
    {
        Task<List<Testimonial>> GetAllTestimonials();
        Task<Testimonial> GetTestimonialById(int id);
		Task<List<Testimonial>> GetTestimonialByUserId(int id);

		Task<int> CreateTestimonial(Testimonial testimonial);
        Task<int> UpdateTestimonial(Testimonial testimonial);
        Task<int> DeleteTestimonial(int id);
        Task<int> AcceptTestimonial(int id);
        Task<int> RejectTestimonial(int id);

    }
}
