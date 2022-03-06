using Microsoft.EntityFrameworkCore;
using ReviewsApp.Models;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.MainReview;
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

    public async Task<IEnumerable<Review>> GetPreviewsAsync(int pageIndex)
    {
        return await AppDbContext.Reviews
            .Include(r => r.Author)
            .Include(r => r.Product)
            .ThenInclude(p => p.Grades)
            .Include(r => r.Tags)
            .Include(r => r.Images)
            .OrderByDescending(r => r.DateAdded)
            .Skip((pageIndex - 1) * ReviewConstrains.ReviewsPageSize)
            .Take(ReviewConstrains.ReviewsPageSize)
            .ToListAsync();
    }

    public async Task<IEnumerable<Review>> GetPreviewsWithTagAsync(Tag tag, int pageIndex)
    {
        return await AppDbContext.Reviews.Where(r => r.Tags.Contains(tag))
            .Include(r => r.Author)
            .Include(r => r.Product)
            .ThenInclude(p => p.Grades)
            .Include(r => r.Tags)
            .Include(r => r.Images)
            .OrderByDescending(r => r.DateAdded)
            .Skip((pageIndex - 1) * ReviewConstrains.ReviewsPageSize)
            .Take(ReviewConstrains.ReviewsPageSize)
            .ToListAsync();
    }

    public async Task<Review> GetReviewByIdAsync(int id)
    {
        return await AppDbContext.Reviews
            .Where(r => r.Id == id)
            .Include(r => r.Author)
            .Include(r => r.Product)
            .ThenInclude(p => p.Grades)
            .Include(r => r.Tags)
            .Include(r => r.Images)
            .FirstOrDefaultAsync();
    }

    public Task<int> GetReviewsAmountAsync()
    {
        return AppDbContext.Reviews.CountAsync();
    }

    public Task<int> GetReviewsWithTagAmountAsync(Tag tag)
    {
        return AppDbContext.Reviews
            .Where(r => r.Tags.Contains(tag))
            .CountAsync();
    }

    private AppDbContext AppDbContext => Context as AppDbContext;
}