using Microsoft.EntityFrameworkCore;
using FilmProjem.Models;

namespace FilmProjem.Data {
    public class UygulamaDbContext : DbContext {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options) { }
        public DbSet<Film> Filmler { get; set; }
    }
}