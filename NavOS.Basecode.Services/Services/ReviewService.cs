using NavOS.Basecode.Data.Interfaces;
using NavOS.Basecode.Data.Models;
using NavOS.Basecode.Data.Repositories;
using NavOS.Basecode.Services.Interfaces;
using NavOS.Basecode.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavOS.Basecode.Services.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public void AddReview(ReviewViewModel review)
        {
            var model = new Review();

            model.ReviewId = Guid.NewGuid().ToString();
            model.BookId = review.BookId;
            model.UserEmail = review.UserEmail;
            model.UserName = review.UserName;
            model.ReviewText = review.ReviewText;
            model.Rate = review.Rate;
            model.DateReviewed = DateTime.Now;

            _reviewRepository.AddReview(model);

        }

        public List<ReviewViewModel> GetReviews()
        {
            var data = _reviewRepository.GetReviews().Select(s => new ReviewViewModel
            {
                BookId = s.BookId,
                UserName = s.UserName,
                ReviewText = s.ReviewText,
                Rate = s.Rate,
                DateReviewed = s.DateReviewed,
            })
            .ToList();

            return data;
        }
    }
}
