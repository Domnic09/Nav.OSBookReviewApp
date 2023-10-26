using NavOS.Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavOS.Basecode.Data.Interfaces
{
    public interface IReviewRepository
    {
        //add review
        void AddReview(Review review);
        //get all reviews with bookId
        IQueryable<Review> GetReviews();
    }
}
