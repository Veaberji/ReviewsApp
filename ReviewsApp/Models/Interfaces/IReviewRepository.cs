using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReviewsApp.Models.Interfaces;

public interface IReviewRepository : IRepository<MainReview.Review, int>
{
    Task<IEnumerable<MainReview.Review>> GetReviewsWithAllInclusions(int pageIndex);
    Task<IEnumerable<MainReview.Review>> GetReviewsForPreviews(int pageIndex);
    Task<int> GetReviewsAmountAsync();
}