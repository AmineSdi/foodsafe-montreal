using FoodSafeMontreal.Application.Establishments;
using FoodSafeMontreal.Infrastructure.Establishments;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddSimpleConsole(options =>
{
    options.SingleLine = true;
    options.TimestampFormat = "HH:mm:ss ";
});

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<FoodEstablishmentSearchService>();
builder.Services.AddSingleton<IFoodEstablishmentRepository, InMemoryFoodEstablishmentRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapGet("/health", () => Results.Ok(new { status = "healthy" }));

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
