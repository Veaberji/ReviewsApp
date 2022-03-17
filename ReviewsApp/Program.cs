using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReviewsApp.Data;
using ReviewsApp.Models;
using ReviewsApp.Models.Common;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.Settings;
using ReviewsApp.Services;
using ReviewsApp.Services.PageModelFactories;
using ReviewsApp.Utils;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration(config =>
{
    var builtConfiguration = config.Build();

    string vaultUrl = builtConfiguration["KeyVaultConfig:VaultURL"];
    string tenantId = builtConfiguration["KeyVaultConfig:TenantId"];
    string clientId = builtConfiguration["KeyVaultConfig:ClientId"];
    string clientSecret = builtConfiguration["KeyVaultConfig:ClientSecretId"];

    var credentials = new ClientSecretCredential(tenantId, clientId, clientSecret);
    var client = new SecretClient(new Uri(vaultUrl), credentials);
    config.AddAzureKeyVault(client, new AzureKeyVaultConfigurationOptions());
});
//todo: Configuration to files/methods
builder.Configuration.Bind("Data:ProjectConfigs", new AppConfigs());
builder.Configuration.Bind("Data:Secrets", new Secrets());

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString(nameof(AppDbContext))));

builder.Services.AddScoped(_ => new BlobServiceClient(
    builder.Configuration[Secrets.AzureBlobConnectionString]));
builder.Services.AddScoped<ImageStoreService>();

builder.Services.AddIdentity<User, IdentityRole>(opts =>
    {
        opts.User.RequireUniqueEmail = true;

        opts.Password.RequireDigit = false;
        opts.Password.RequireLowercase = false;
        opts.Password.RequireNonAlphanumeric = false;
        opts.Password.RequireUppercase = false;
        opts.Password.RequiredLength = 1;
        opts.Password.RequiredUniqueChars = 0;
    })
    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opts =>
    {
        opts.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        opts.SlidingExpiration = true;
        opts.AccessDeniedPath = "/error";
    });
builder.Services.AddAuthentication().AddFacebook(options =>
{
    options.AppId = builder.Configuration[Secrets.FacebookWebAppId];
    options.AppSecret = builder.Configuration[Secrets.FacebookWebAppSecret];
    options.AccessDeniedPath = "/Account/AccessDenied";
})
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration[Secrets.GoogleWebClientId];
        options.ClientSecret = builder.Configuration[Secrets.GoogleWebClientSecret];
        options.AccessDeniedPath = "/Account/AccessDenied";
    });
builder.Services.AddScoped<SocialLoginHelper>();

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

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePages();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseStatusCodePagesWithReExecute("/error", "?statusCode={0}");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "error",
            pattern: "/error",
            defaults: new { controller = "Error", action = "Error" });
        endpoints.MapControllerRoute(
            name: "settings",
            pattern: "/settings",
            defaults: new { controller = "Settings", action = "SetSettings" });
        endpoints.MapControllerRoute(
            name: "userProfile",
            pattern: "/profile-{userName}/{pageIndex?}",
            defaults: new { controller = "Profile", action = "Index" });
        endpoints.MapControllerRoute(
            name: "adminPanel",
            pattern: "/admin",
            defaults: new { controller = "Admin", action = "Index" });
        endpoints.MapControllerRoute(
            name: "createReview",
            pattern: "/{userName}-create",
            defaults: new { controller = "Review", action = "CreateReview" });
        endpoints.MapControllerRoute(
            name: "reviewWithTag",
            pattern: "/reviewsWithTag-{tagText}/page{pageIndex=1}",
            defaults: new { controller = "Review", action = "ReviewsWithTag" });
        endpoints.MapControllerRoute(
            name: "home",
            pattern: "/page{pageIndex}",
            defaults: new { controller = "Review", action = "LastReviews" });
        endpoints.MapControllerRoute(
            name: "singleReview",
            pattern: "/review{id}",
            defaults: new { controller = "Review", action = "SingleReview" });
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Review}/{action=LastReviews}/{id?}");
    });

app.Run();