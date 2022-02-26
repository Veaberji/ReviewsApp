using Microsoft.EntityFrameworkCore;
using ReviewsApp.Models;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.Settings.Constrains;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsApp.Data;

public class ReviewRepository : Repository<Review, int>, IReviewRepository
{
    public ReviewRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Review>> GetReviewsWithAllInclusions(int pageIndex)
    {
        return await AppDbContext.Reviews
            .Include(r => r.Author)
            .Include(r => r.Product)
            .Include(r => r.Product.Grades)
            .OrderByDescending(r => r.DateAdded)
            .Skip((pageIndex - 1) * ReviewConstrains.ReviewsPageSize)
            .Take(ReviewConstrains.ReviewsPageSize)
            .ToListAsync();
    }

    private AppDbContext AppDbContext => Context as AppDbContext;
}