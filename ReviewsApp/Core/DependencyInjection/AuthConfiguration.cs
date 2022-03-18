using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ReviewsApp.Models;
using ReviewsApp.Models.Common;
using ReviewsApp.Models.Settings;
using ReviewsApp.Utils;
using System;

namespace ReviewsApp.Core.DependencyInjection
{
    public static class AuthConfiguration
    {
        public static WebApplicationBuilder AddAuthenticationServices(
            this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentity<User, IdentityRole>(opts =>
                {
                    opts.User.RequireUniqueEmail = true;

                    opts.Password.RequireDigit = false;
                    opts.Password.RequireLowercase = false;
                    opts.Password.RequireNonAlphanumeric = false;
                    opts.Password.RequireUppercase = false;
                    opts.Password.RequiredLength = 1;
                    opts.Password.RequiredUniqueChars = 0;
                })
                .AddEntityFrameworkStores<AppDbContext>();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opts =>
                {
                    opts.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                    opts.SlidingExpiration = true;
                    opts.AccessDeniedPath = "/error";
                });
            builder.Services.AddAuthentication().AddFacebook(options =>
                {
                    options.AppId = builder.Configuration[Secrets.FacebookWebAppId];
                    options.AppSecret = builder.Configuration[Secrets.FacebookWebAppSecret];
                    options.AccessDeniedPath = "/Account/AccessDenied";
                })
                .AddGoogle(options =>
                {
                    options.ClientId = builder.Configuration[Secrets.GoogleWebClientId];
                    options.ClientSecret = builder.Configuration[Secrets.GoogleWebClientSecret];
                    options.AccessDeniedPath = "/Account/AccessDenied";
                });
            builder.Services.AddScoped<SocialLoginHelper>();

            return builder;
        }
    }
}
