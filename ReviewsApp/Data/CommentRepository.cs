using ReviewsApp.Models;
using ReviewsApp.Models.Interfaces;

namespace ReviewsApp.Data;

public class CommentRepository : Repository<Comment, int>, ICommentRepository
{
    public CommentRepository(AppDbContext context) : base(context)
    {
    }
}