using Microsoft.EntityFrameworkCore;
using ReviewsApp.Models;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.MainReview;
using ReviewsApp.Models.Settings;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsApp.Data;

public class TagRepository : Repository<Tag, int>, ITagRepository
{
    public TagRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Tag> GetByTextAsync(string text)
    {
        return await AppDbContext.Tags.FirstOrDefaultAsync(t => t.Text == text);
    }

    public List<Tag> GetTopTags()
    {
        return AppDbContext.Tags
            .OrderByDescending(t => t.Count)
            .ThenBy(t => t.Text)
            .Take(TagCloudConfigs.TagCloudSize)
            .ToList();
    }

    public List<Tag> GetTagsStartWith(string prefix)
    {
        return AppDbContext.Tags
            .Where(tag => tag.Text.StartsWith(prefix.ToLower()))
            .ToList();
    }

    private AppDbContext AppDbContext => Context as AppDbContext;
}