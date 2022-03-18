using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using ReviewsApp.Models.Settings;

namespace ReviewsApp.Core.DependencyInjection
{
    public static class ObjectsBindingConfiguration
    {
        public static WebApplicationBuilder BindObjects(
            this WebApplicationBuilder builder)
        {
            builder.Configuration.Bind("Data:ProjectConfigs", new AppConfigs());
            builder.Configuration.Bind("Data:Secrets", new Secrets());

            return builder;
        }
    }
}
