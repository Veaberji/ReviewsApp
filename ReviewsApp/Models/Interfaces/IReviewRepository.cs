using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReviewsApp.Models.Interfaces;

public interface IReviewRepository : IRepository<Review.Review, int>
{
    Task<IEnumerable<Review.Review>> GetReviewsWithAllInclusions(int pageIndex);
}