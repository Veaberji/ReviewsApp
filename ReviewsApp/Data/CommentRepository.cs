using Microsoft.EntityFrameworkCore;
using ReviewsApp.Models;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.MainReview;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsApp.Data;

public class CommentRepository : Repository<Comment, int>, ICommentRepository
{
    public CommentRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Comment>> GetReviewCommentsWithAuthorsAsync(int reviewId)
    {
        return await AppDbContext.Comments.Where(c => c.ReviewId == reviewId)
            .Include(c => c.Author)
            .ThenInclude(a => a.Reviews)
            .ThenInclude(r => r.Likes)
            .OrderBy(c => c.PublishingDate)
            .ToListAsync();
    }

    private AppDbContext AppDbContext => Context as AppDbContext;
}