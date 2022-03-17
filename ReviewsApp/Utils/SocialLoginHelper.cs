using Microsoft.AspNetCore.Identity;
using ReviewsApp.Models.Common;
using ReviewsApp.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ReviewsApp.Utils
{
    public class SocialLoginHelper
    {
        private readonly IUnitOfWork _unitOfWork;

        public SocialLoginHelper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
            string name = GetName(info).Replace(" ", "");
            var users = _unitOfWork.Users
                .Find(u => u.UserName.Contains(name))
                .Select(u => u.UserName)
                .ToList();

            return GetPossibleName(users, name);
        }

        private string InitSocialDisplayName(ExternalLoginInfo info)
        {
            string name = FormatName(info);
            var users = _unitOfWork.Users
                .Find(u => u.DisplayName.Contains(name))
                .Select(u => u.DisplayName)
                .ToList();

            return GetPossibleName(users, name);
        }

        private string GetEmail(ExternalLoginInfo info)
        {
            return info.Principal.FindFirst(ClaimTypes.Email)?.Value;
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

        private static string FormatName(ExternalLoginInfo info)
        {
            return GetName(info).Replace(" ", "");
        }

        private static string GetName(ExternalLoginInfo info)
        {
            return info.Principal.FindFirst(ClaimTypes.Name)?.Value;
        }
    }
}
