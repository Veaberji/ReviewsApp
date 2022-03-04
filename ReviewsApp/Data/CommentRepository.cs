using ReviewsApp.Models;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.MainReview;

namespace ReviewsApp.Data;

public class CommentRepository : Repository<Comment, int>, ICommentRepository
{
    public CommentRepository(AppDbContext context) : base(context)
    {
    }
}