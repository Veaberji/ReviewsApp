using ReviewsApp.Models.MainReview;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReviewsApp.Models.Interfaces;

public interface IReviewRepository : IRepository<MainReview.Review, int>
{
    Task<IEnumerable<Review>> GetReviewsWithAllInclusions(int pageIndex);
    Task<IEnumerable<Review>> GetReviewsForPreviews(int pageIndex);
    Task<int> GetReviewsAmountAsync();
}