using ReviewsApp.Models.Common;
using ReviewsApp.Models.MainReview;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReviewsApp.Models.Interfaces;

public interface IReviewRepository : IRepository<Review, int>
{
    Task<IEnumerable<Review>> GetPreviewsAsync(int pageIndex);
    Task<IEnumerable<Review>> GetPreviewsWithTagAsync(Tag tag, int pageIndex);
    Task<IEnumerable<Review>> GetPreviewsByAuthorIdAsync(string authorId, int pageIndex);
    Task<Review> GetNoCommentsFullReviewByIdAsync(int id);
    Task<Review> GetFullReviewByIdAsync(int id);
    Task<int> GetAmountOfReviewsAsync();
    Task<int> GetAmountOfReviewsWithTagAsync(Tag tag);
    Task<int> GetAmountOfReviewsByAuthorAsync(User author);
    Task<IEnumerable<Review>> GetTopRatedReviewsHeadersAsync();
}