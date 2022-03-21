using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ReviewsApp.Models.Settings;
using ReviewsApp.Services;

namespace ReviewsApp.Core.DependencyInjection
{
    public static class FeaturesServicesConfiguration
    {
        public static WebApplicationBuilder AddFeaturesServices(
            this WebApplicationBuilder builder)
        {
            builder.AddSearchService();
            return builder;
        }

        private static WebApplicationBuilder AddSearchService(
            this WebApplicationBuilder builder)
        {
            var queryKey =
                builder.Configuration[Secrets.AzureSearchQueryKey];
            builder.Services.AddScoped(p =>
                ActivatorUtilities.CreateInstance<SearchService>(p, queryKey));
            return builder;
        }
    }
}
