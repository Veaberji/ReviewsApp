using ReviewsApp.Models;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.MainReview;

namespace ReviewsApp.Data;

public class ImageRepository : Repository<Image, int>, IImageRepository
{
    public ImageRepository(AppDbContext context) : base(context)
    {
    }
}