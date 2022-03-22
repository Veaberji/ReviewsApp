using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using ReviewsApp.Models.Settings;
using ReviewsApp.Services;
using ReviewsApp.ViewModels.Settings;
using System;

namespace ReviewsApp.Controllers
{
    public class SettingsController : Controller
    {
        private readonly SettingsService _settingsService;

        public SettingsController(SettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public IActionResult SetSettings()
        {
            var model = new SettingsViewModel
            {
                Themes = _settingsService.GetThemes(),
                Cultures = _settingsService.GetCultures()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult SetTheme(Themes theme)
        {
            SetCookie(AppConfigs.ThemeCookie, theme.ToString());
            return RedirectToAction("SetSettings");
        }

        [HttpPost]
        public IActionResult SetCulture(string culture)
        {
            string key = CookieRequestCultureProvider.DefaultCookieName;
            string value = CookieRequestCultureProvider.MakeCookieValue(
                    new RequestCulture(culture));
            SetCookie(key, value);
            return RedirectToAction("SetSettings");
        }

        private void SetCookie(string key, string value)
        {
            var cookie = new CookieOptions
            {
                Expires = DateTime.Now.AddYears(AppConfigs.CookieLivePeriodYears)
            };
            Response.Cookies.Append(key, value, cookie);
        }
    }
}
