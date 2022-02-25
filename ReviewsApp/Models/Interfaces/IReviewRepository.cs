using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReviewsApp.Models.Interfaces;

public interface IReviewRepository : IRepository<Review, int>
{
    Task<IEnumerable<Review>> GetReviewsWithAllInclusions(int pageIndex);
}