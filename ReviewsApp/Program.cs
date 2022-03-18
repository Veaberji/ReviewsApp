using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReviewsApp.Core.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureAzureKeyVault();
builder.BindObjects();

builder.AddDbContextService();
builder.AddImagesStoreService();
builder.AddAuthenticationServices();
builder.AddModelsServices();
builder.Services.AddControllersWithViews();
builder.AddDevServices();


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