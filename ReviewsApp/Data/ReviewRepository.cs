using Microsoft.EntityFrameworkCore;
using ReviewsApp.Models;
using ReviewsApp.Models.Common;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.MainReview;
using ReviewsApp.Models.Settings;
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
        var reviews = AppDbContext.Reviews;
        return await AddPreviewsIncludes(reviews, pageIndex).ToListAsync();
    }

    public async Task<IEnumerable<Review>> GetPreviewsWithTagAsync(Tag tag, int pageIndex)
    {
        var reviews = AppDbContext.Reviews.Where(r => r.Tags.Contains(tag));
        return await AddPreviewsIncludes(reviews, pageIndex).ToListAsync();
    }

    public async Task<IEnumerable<Review>> GetPreviewsByAuthorIdAsync(string authorId, int pageIndex)
    {
        var reviews = AppDbContext.Reviews.Where(r => r.AuthorId == authorId);
        return await AddPreviewsIncludes(reviews, pageIndex).ToListAsync();
    }

    public async Task<IEnumerable<Review>> GetTopRatedReviewsHeadersAsync()
    {
        return await AppDbContext.Reviews
            .Where(r => r.Product.Grades.Count > 0)
            .OrderByDescending(r => r.Product.Grades.Average(g => g.Grade))
            .Take(AppConfigs.TopRatedReviewsAmount)
            .Include(r => r.Author)
            .ThenInclude(a => a.Reviews)
            .ThenInclude(r => r.Likes)
            .Include(r => r.Product)
            .ThenInclude(p => p.Grades)
            .ToListAsync();
    }

    public async Task<Review> GetNoCommentsFullReviewByIdAsync(int id)
    {
        return await GetReviewWithIncludes(id)
            .FirstOrDefaultAsync();
    }

    public async Task<Review> GetFullReviewByIdAsync(int id)
    {
        return await GetReviewWithIncludes(id)
            .Include(r => r.Comments)
            .FirstOrDefaultAsync();
    }

    public async Task<int> GetAmountOfReviewsAsync()
    {
        return await AppDbContext.Reviews.CountAsync();
    }

    public async Task<int> GetAmountOfReviewsWithTagAsync(Tag tag)
    {
        return await AppDbContext.Reviews
            .Where(r => r.Tags.Contains(tag))
            .CountAsync();
    }

    public async Task<int> GetAmountOfReviewsByAuthorAsync(User author)
    {
        return await AppDbContext.Reviews
            .Where(r => r.Author == author)
            .CountAsync();
    }

    private AppDbContext AppDbContext => Context as AppDbContext;

    private static IQueryable<Review> AddPreviewsIncludes(IQueryable<Review> reviews, int pageIndex)
    {
        return reviews.OrderByDescending(r => r.DateAdded)
            .Skip((pageIndex - 1) * AppConfigs.PreviewsPerPage)
            .Take(AppConfigs.PreviewsPerPage)
            .Include(r => r.Author)
            .ThenInclude(a => a.Reviews)
            .ThenInclude(r => r.Likes)
            .Include(r => r.Product)
            .ThenInclude(p => p.Grades)
            .Include(r => r.Tags)
            .Include(r => r.Images.Take(1));
    }
    private IQueryable<Review> GetReviewWithIncludes(int id)
    {
        return AppDbContext.Reviews
            .Where(r => r.Id == id)
            .Include(r => r.Author)
            .ThenInclude(a => a.Reviews)
            .ThenInclude(r => r.Likes)
            .Include(r => r.Product)
            .ThenInclude(p => p.Grades)
            .Include(r => r.Tags)
            .Include(r => r.Images)
            .Include(r => r.Likes);
    }
}