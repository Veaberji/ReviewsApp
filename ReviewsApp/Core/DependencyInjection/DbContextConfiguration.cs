using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReviewsApp.Models;

namespace ReviewsApp.Core.DependencyInjection
{
    public static class DbContextConfiguration
    {
        public static WebApplicationBuilder AddDbContextService(
            this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString(nameof(AppDbContext))));

            return builder;
        }
    }
}
