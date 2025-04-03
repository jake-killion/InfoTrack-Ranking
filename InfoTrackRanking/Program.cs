using InfoTrackRanking.Database;
using InfoTrackRanking.Models;
using InfoTrackRanking.Services;
using InfoTrackRanking.UIService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUIScraperService, UIScraperService>();
builder.Services.AddScoped<IUIRepositoryService<RankHistoryViewModel>, UIRankHistoryService>();

builder.Services.AddScoped<IScraperService, GoogleScraperService>();

builder.Services.AddScoped<IRepository<RankHistory>, RankHistoryRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Shared/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Ranking}/{action=Index}/{id?}");

app.Run();
