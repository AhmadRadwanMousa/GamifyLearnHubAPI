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
    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialRepository _testimonialRepository;
        public TestimonialService(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }
        public async Task<int> AcceptTestimonial(int id)
        {
            var rowsAffected = await _testimonialRepository.AcceptTestimonial(id);
            return rowsAffected;
        }

        public async Task<int> CreateTestimonial(Testimonial testimonial)
        {
            var createdId = await _testimonialRepository.CreateTestimonial(testimonial);
            return createdId;
        }

        public async Task<int> DeleteTestimonial(int id)
        {
            var rowsAffected = await _testimonialRepository.DeleteTestimonial(id);
            return rowsAffected;
        }

        public async Task<List<Testimonial>> GetAllTestimonials()
        {
            return await  _testimonialRepository.GetAllTestimonials();
        }

        public async Task<Testimonial> GetTestimonialById(int id)
        {
            return await _testimonialRepository.GetTestimonialById(id);
        }

        public async Task<int> RejectTestimonial(int id)
        {
            var rowsAffected = await _testimonialRepository.RejectTestimonial(id);
            return rowsAffected;
        }

        public async Task<int> UpdateTestimonial(Testimonial testimonial)
        {
            var rowsAffected = await _testimonialRepository.UpdateTestimonial(testimonial);
            return rowsAffected;
        }
		public async Task<List<Testimonial>> GetTestimonialByUserId(int id) 
		{
			return await _testimonialRepository.GetTestimonialByUserId(id);
		}

	}
}
