using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ReviewsApp.Models.Common;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.Settings;
using System;
using System.Collections.Generic;
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

        public async Task SetDisplayName(string name)
        {
            var existingNames = (await _unitOfWork.Users.GetAllAsync())
                .Select(u => u.DisplayName).ToList();
            if (existingNames.Contains(name))
            {
                throw new ArgumentException(
                    $"The name'{name}' is already exists");
            }
            var user = await GetCurrentUser();
            user.DisplayName = name;
            await _unitOfWork.CompleteAsync();
        }

        public string GetPossibleUserName(string name)
        {
            var users = _unitOfWork.Users
                .Find(u => u.UserName.Contains(name))
                .Select(u => u.UserName)
                .ToList();

            return GetPossibleName(users, name);
        }

        public string GetPossibleDisplayName(string name)
        {
            var users = _unitOfWork.Users
                .Find(u => u.DisplayName.Contains(name))
                .Select(u => u.DisplayName)
                .ToList();

            return GetPossibleName(users, name);
        }

        public Task<User> GetCurrentUser()
        {
            return _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
        }

        private static string GetPossibleName(List<string> users, string name)
        {
            int count = users.Count;
            string possibleName = name;
            while (users.Contains(possibleName))
            {
                possibleName = name + ++count;
            }

            return possibleName;
        }
    }
}
