using Microsoft.AspNetCore.Http;
using ReviewsApp.Models.Settings;

namespace ReviewsApp.Services
{
    public class SettingsService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SettingsService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetTheme()
        {
            string themeName = _httpContextAccessor.HttpContext?
                .Request.Cookies[AppConfigs.ThemeCookie] ?? "";
            return (themeName.Length > 0 ?
                themeName : AppConfigs.DefaultTheme) + ".min.css";
        }
    }
}
