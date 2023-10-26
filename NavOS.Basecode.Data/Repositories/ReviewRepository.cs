using Basecode.Data.Repositories;
using NavOS.Basecode.Data.Interfaces;
using NavOS.Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavOS.Basecode.Data.Repositories
{
    public class ReviewRepository : BaseRepository, IReviewRepository
    {
        public ReviewRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {


        }
        public void AddReview(Review review)
        {
            this.GetDbSet<Review>().Add(review);
            UnitOfWork.SaveChanges();
        }
        public IQueryable<Review> GetReviews()
        {
            return this.GetDbSet<Review>();
        }
    }
}
