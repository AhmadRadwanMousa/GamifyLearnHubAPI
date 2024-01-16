using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Service
{
    public class UserReviewService : IUserReviewService
    {
        private readonly IUserReviewRepository _userReviewRepository;

        public UserReviewService(IUserReviewRepository userReviewRepository)
        {
            _userReviewRepository = userReviewRepository;
        }

       

        public async Task<int> CreateUserReview(Userreview userReview)
        {
            return await _userReviewRepository.CreateUserReview(userReview);
        }

        public async Task<int> DeleteUserReview(int id)
        {
            return await _userReviewRepository.DeleteUserReview(id);
        }

        public async Task<List<Userreview>> GetAllUserReviews()
        {
            return await _userReviewRepository.GetAllUserReviews();
        }

        public async Task<List<FinishedProgram>> GetFinishedPrograms(int userId)
        {
            var reviews = await _userReviewRepository.GetAllUserReviews();
            var userReview = reviews.Where(r=> r.Userid == userId).ToList();
            var finishedPrograms =  await _userReviewRepository.GetFinishedPrograms(userId);

            return finishedPrograms.Where(p=> !userReview.Any(ur=> ur.Programid == p.ProgramId)).ToList();

        }

        public async Task<Userreview> GetUserReviewById(int id)
        {
            return await _userReviewRepository.GetUserReviewById(id);
        }

        public async Task<int> UpdateUserReview(Userreview userReview)
        {
            return await _userReviewRepository.UpdateUserReview(userReview);
        }
    }
}
