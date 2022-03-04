using ReviewsApp.Models.MainReview;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReviewsApp.Models.Interfaces;

public interface ITagRepository : IRepository<Tag, int>
{
    Task<Tag> GetByTextAsync(string text);
    List<Tag> GetTopTags();
    List<Tag> GetTagsStartWith(string prefix);
}