using ReviewsApp.Models;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.Review;

namespace ReviewsApp.Data;

public class LikeRepository : Repository<Like, int>, ILikeRepository
{
    public LikeRepository(AppDbContext context) : base(context)
    {
    }
}