using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using ReviewsApp.Models.Settings;
using System.Collections.Generic;
using System.Globalization;

namespace ReviewsApp.Core.DependencyInjection
{
    public static class LocalizationConfiguration
    {
        public static WebApplicationBuilder ConfigureControllersWithViews(
            this WebApplicationBuilder builder)
        {
            AddLocalization(builder);
            AddControllersWithViewsWithLocalization(builder);
            ConfigureCultures(builder);
            return builder;
        }

        private static void AddLocalization(WebApplicationBuilder builder)
        {
            builder.Services.AddLocalization(opts =>
                opts.ResourcesPath = "Resources");
        }

        private static void AddControllersWithViewsWithLocalization(
            WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
        }

        private static void ConfigureCultures(WebApplicationBuilder builder)
        {
            builder.Services.Configure<RequestLocalizationOptions>(opts =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new(CultureConfigs.EnCulture),
                    new(CultureConfigs.RuCulture)
                };
                opts.DefaultRequestCulture =
                    new RequestCulture(CultureConfigs.DefaultCulture);
                opts.SupportedCultures = supportedCultures;
                opts.SupportedUICultures = supportedCultures;
                opts.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                };
            });
        }
    }
}

