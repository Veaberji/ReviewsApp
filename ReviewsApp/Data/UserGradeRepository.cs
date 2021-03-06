using ReviewsApp.Models;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.MainReview;

namespace ReviewsApp.Data;

public class UserGradeRepository : Repository<UserGrade, int>, IUserGradeRepository
{
    public UserGradeRepository(AppDbContext context) : base(context)
    {
    }
}