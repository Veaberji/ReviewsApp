using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ReviewsApp.Core.DependencyInjection
{
    public static class DevelopmentServicesConfiguration
    {
        public static WebApplicationBuilder AddDevServices(
            this WebApplicationBuilder builder)
        {
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

            return builder;
        }

    }
}
