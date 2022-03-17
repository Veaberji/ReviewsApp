using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ReviewsApp.Models.Common;
using ReviewsApp.Models.Settings;
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

        public async Task<string> GetUserDisplayName()
        {
            var user = await _userManager
                .GetUserAsync(_httpContextAccessor.HttpContext?.User);
            return user.DisplayName;
        }

        public async Task<bool> IsAllowedUser(string userId)
        {
            var user = await _userManager
                .GetUserAsync(_httpContextAccessor.HttpContext?.User);
            bool isAdmin = await _userManager.IsInRoleAsync(user, AppRoles.AdminRole);
            return isAdmin || userId == user.Id;
        }
    }
}
