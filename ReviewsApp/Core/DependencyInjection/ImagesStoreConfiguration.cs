using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ReviewsApp.Models.Settings;
using ReviewsApp.Services;

namespace ReviewsApp.Core.DependencyInjection
{
    public static class ImagesStoreConfiguration
    {
        public static WebApplicationBuilder AddImagesStoreService(
            this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(_ => new BlobServiceClient(
                builder.Configuration[Secrets.AzureBlobConnectionString]));
            builder.Services.AddScoped<ImageStoreService>();

            return builder;
        }
    }
}
