using Microsoft.EntityFrameworkCore; // BU SATIRI EKLEDİK
using FilmProjem.Data;              // BU SATIRI EKLEDİK (Data klasöründeki context için)

var builder = WebApplication.CreateBuilder(args);

// 1. ADIM: Veritabanı Servisini Buraya Ekliyoruz
builder.Services.AddDbContext<UygulamaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.UseStaticFiles();
app.Run();