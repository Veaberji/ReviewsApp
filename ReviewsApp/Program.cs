using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReviewsApp.Data;
using ReviewsApp.Models;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.Settings;
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

builder.Configuration.Bind("Data:Roles", new AppRoles());
builder.Configuration.Bind("Data:ProjectConfigs", new AppConfigs());
builder.Configuration.Bind("Data:Secrets", new Secrets());

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString(nameof(AppDbContext))));

builder.Services.AddIdentity<User, IdentityRole>(opts =>
    {
        opts.User.RequireUniqueEmail = true;
        opts.User.AllowedUserNameCharacters = Constrains.AllowedUserNameCharacters;

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
        opts.AccessDeniedPath = "/Account/Login";
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

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddHttpContextAccessor();

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
    app.UseExceptionHandler("/Home/Error");
    app.UseStatusCodePagesWithReExecute("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "Settings",
            pattern: "Settings",
            defaults: new { controller = "Settings", action = "SetSettings" });
        endpoints.MapDefaultControllerRoute();
    });

app.Run();