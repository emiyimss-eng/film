using Microsoft.EntityFrameworkCore;
using FilmProjem.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. ADIM: Veritabanı Servisi
builder.Services.AddDbContext<UygulamaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
// 2. ADIM: Statik dosyalar için bu satır yeterlidir
app.UseStaticFiles(); 

app.UseRouting();
app.UseAuthorization();

// 3. ADIM: Hatalı olan .MapStaticAssets() ve .WithStaticAssets() kısımlarını sildik
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();