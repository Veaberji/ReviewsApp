using ReviewsApp.Models.Review;

namespace ReviewsApp.Models.Interfaces;

public interface ICommentRepository : IRepository<Comment, int>
{
}