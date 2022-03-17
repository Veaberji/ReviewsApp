using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ReviewsApp.Models.Common;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.Settings;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsApp.Services
{
    public class UserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(UserManager<User> userManager,
            IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
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

        public string GetCurrentUserId()
        {
            return _userManager.GetUserId(_httpContextAccessor.HttpContext?.User);
        }

        public bool IsUserAuthenticated()
        {
            return _httpContextAccessor.HttpContext?
                .User.Identity?.IsAuthenticated ?? false;
        }

        public User GetUserByUserName(string userName)
        {
            return _unitOfWork.Users
                .Find(u => u.UserName == userName)
                .FirstOrDefault(); ;
        }
    }
}
