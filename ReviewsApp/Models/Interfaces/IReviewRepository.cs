using ReviewsApp.Models.MainReview;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReviewsApp.Models.Interfaces;

public interface IReviewRepository : IRepository<Review, int>
{
    Task<IEnumerable<Review>> GetPreviewsAsync(int pageIndex);
    Task<IEnumerable<Review>> GetPreviewsWithTagAsync(Tag tag, int pageIndex);
    Task<Review> GetReviewByIdAsync(int id);
    Task<int> GetReviewsAmountAsync();
    Task<int> GetReviewsWithTagAmountAsync(Tag tag);
}