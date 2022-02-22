﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewsApp.Models.Settings;
using ReviewsApp.ViewModels;
using System;

namespace ReviewsApp.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult SetSettings()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetSettings(SettingsViewModel model)
        {
            var theme = model.Theme;
            if (!Enum.IsDefined(typeof(Themes), theme))
            {
                return View(model);
            }

            var cookie = new CookieOptions
            {
                Expires = DateTime.Now.AddYears(AppConfigs.CookieLivePeriodYears)
            };
            Response.Cookies.Append(AppConfigs.ThemeCookie, ((int)theme).ToString(), cookie);
            return RedirectToAction("SetSettings");
        }
    }
}
