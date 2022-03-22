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
            builder.Configuration.Bind("Data:TagCloudConfigs", new TagCloudConfigs());
            builder.Configuration.Bind("Data:ImageConfigs", new ImageConfigs());
            builder.Configuration.Bind("Data:PageConfigs", new PageConfigs());
            builder.Configuration.Bind("Data:SearchConfigs", new SearchConfigs());
            builder.Configuration.Bind("Data:Secrets", new Secrets());
            builder.Configuration.Bind("Data:CultureConfigs", new CultureConfigs());

            return builder;
        }
    }
}
