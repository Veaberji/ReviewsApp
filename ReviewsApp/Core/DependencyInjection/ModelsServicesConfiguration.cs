using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ReviewsApp.Data;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Services;
using ReviewsApp.Services.PageModelFactories;
using System;

namespace ReviewsApp.Core.DependencyInjection
{
    public static class ModelsServicesConfiguration
    {
        public static WebApplicationBuilder AddModelsServices(
            this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<SettingsService>();
            builder.Services.AddScoped<PaginationService>();
            builder.Services.AddScoped<ReviewService>();
            builder.Services.AddScoped<GradeService>();
            builder.Services.AddScoped<TagsService>();
            builder.Services.AddScoped<LikeService>();
            builder.Services.AddScoped<HomeViewModelFactory>();
            builder.Services.AddScoped<ProfileModelFactory>();
            builder.Services.AddScoped<ReviewPageViewModelFactory>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return builder;
        }
    }
}
