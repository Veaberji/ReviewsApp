using ReviewsApp.Models;
using ReviewsApp.Models.Common;
using ReviewsApp.Models.Interfaces;

namespace ReviewsApp.Data;

public class UserRepository : Repository<User, string>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}