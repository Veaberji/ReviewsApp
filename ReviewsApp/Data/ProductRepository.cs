using ReviewsApp.Models;
using ReviewsApp.Models.Interfaces;

namespace ReviewsApp.Data;

public class ProductRepository : Repository<Product, int>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}