using ReviewsApp.Models.MainReview;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReviewsApp.Models.Interfaces;

public interface ICommentRepository : IRepository<Comment, int>
{
    Task<IEnumerable<Comment>> GetReviewCommentsWithAuthorsAsync(int reviewId);
}