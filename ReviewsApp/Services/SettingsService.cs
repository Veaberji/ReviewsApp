using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using ReviewsApp.Core.Utils;
using ReviewsApp.Models.Settings;
using System.Collections.Generic;
using System.Linq;

namespace ReviewsApp.Services
{
    public class SettingsService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOptions<RequestLocalizationOptions> _options;
        public SettingsService(IHttpContextAccessor httpContextAccessor,
            IOptions<RequestLocalizationOptions> options)
        {
            _httpContextAccessor = httpContextAccessor;
            _options = options;
        }

        public string GetTheme()
        {
            string themeName = _httpContextAccessor.HttpContext?
                .Request.Cookies[AppConfigs.ThemeCookie] ?? "";
            return (themeName.Length > 0 ?
                themeName : AppConfigs.DefaultTheme) + ".min.css";
        }

        public IEnumerable<Themes> GetThemes()
        {
            return EnumUtils.GetValues<Themes>();
        }

        public IEnumerable<SelectListItem> GetCultures()
        {
            return _options.Value.SupportedUICultures?
                .Select(c => new SelectListItem { Value = c.Name, Text = c.NativeName })
                .ToList();
        }
    }
}
