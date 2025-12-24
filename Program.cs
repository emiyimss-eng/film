using Microsoft.EntityFrameworkCore;
using FilmProjem.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. ADIM: Veritabanı Servisi (PostgreSQL için UseNpgsql kullanıyoruz)
builder.Services.AddDbContext<UygulamaDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); // Burayı Npgsql yaptık!

builder.Services.AddControllersWithViews();

var app = builder.Build();

// 2. ADIM: Veritabanını ve Tabloları Otomatik Oluşturma
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<UygulamaDbContext>();
    context.Database.EnsureCreated(); // Veritabanı boşsa tabloları senin yerine kurar
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); 

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();