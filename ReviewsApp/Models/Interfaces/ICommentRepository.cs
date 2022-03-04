using ReviewsApp.Models.MainReview;

namespace ReviewsApp.Models.Interfaces;

public interface ICommentRepository : IRepository<Comment, int>
{
}