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
using ReviewsApp.Models;
using ReviewsApp.Models.Settings;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((context, config) =>
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
    //todo: local works
    options.AppId = builder.Configuration["Authentication:Facebook:LocalAppId"];
    options.AppSecret = builder.Configuration["Authentication:Facebook:LocalAppSecret"];

    options.AccessDeniedPath = "/";
})
    .AddGoogle(options =>
    {
        //todo:local
        options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
    });

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();