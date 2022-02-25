using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ReviewsApp.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReviewsApp.Services
{
    public class UserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GetCurrentUserName()
        {
            var userId = _httpContextAccessor.HttpContext?.User
                .FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.FindByIdAsync(userId);

            return user.DisplayName;
        }
    }
}
