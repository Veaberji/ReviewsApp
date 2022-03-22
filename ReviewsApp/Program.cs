using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using ReviewsApp.Core.DependencyInjection;
using ReviewsApp.Core.MiddlewareConfigs;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureAzureKeyVault();
builder.BindObjects();

builder.AddDbContextService();
builder.AddImagesStoreService();
builder.AddAuthenticationServices();
builder.AddModelsServices();
builder.AddFeaturesServices();
builder.ConfigureControllersWithViews();

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

app.UseRequestLocalization();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRoutes();
});

app.Run();