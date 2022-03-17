using Microsoft.AspNetCore.Identity;
using ReviewsApp.Models.Common;
using ReviewsApp.Services;
using System.Security.Claims;

namespace ReviewsApp.Utils
{
    public class SocialLoginHelper
    {
        private readonly UserService _userService;

        public SocialLoginHelper(UserService userService)
        {
            _userService = userService;
        }

        public User CreateUser(ExternalLoginInfo info)
        {
            return new User
            {
                Email = GetEmail(info),
                UserName = InitSocialUserName(info),
                DisplayName = InitSocialDisplayName(info)
            };
        }

        private string InitSocialUserName(ExternalLoginInfo info)
        {
            string name = GetFormattedName(info);
            return _userService.GetPossibleUserName(name);
        }

        private string InitSocialDisplayName(ExternalLoginInfo info)
        {
            string name = GetName(info);
            return _userService.GetPossibleDisplayName(name);
        }

        private string GetEmail(ExternalLoginInfo info)
        {
            return info.Principal.FindFirst(ClaimTypes.Email)?.Value;
        }



        private static string GetFormattedName(ExternalLoginInfo info)
        {
            return GetName(info).Replace(" ", "");
        }

        private static string GetName(ExternalLoginInfo info)
        {
            return info.Principal.FindFirst(ClaimTypes.Name)?.Value;
        }
    }
}
