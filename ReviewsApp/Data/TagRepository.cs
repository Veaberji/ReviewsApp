using ReviewsApp.Models;
using ReviewsApp.Models.Interfaces;

namespace ReviewsApp.Data;

public class TagRepository : Repository<Tag, int>, ITagRepository
{
    public TagRepository(AppDbContext context) : base(context)
    {
    }
}