using ReviewsApp.Models;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.MainReview;

namespace ReviewsApp.Data;

public class ProductRepository : Repository<Product, int>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}