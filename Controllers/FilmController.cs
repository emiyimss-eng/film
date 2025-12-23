using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmProjem.Models;
using FilmProjem.Data;

namespace FilmProjem.Controllers
{
    public class FilmController : Controller
    {
        private readonly UygulamaDbContext _context;

        public FilmController(UygulamaDbContext context)
        {
            _context = context;
        }

        // 1. LİSTELEME (Read)
        public async Task<IActionResult> Index()
        {
            var filmler = await _context.Filmler.ToListAsync();
            return View(filmler);
        }

        // 2. EKLEME SAYFASI (Görüntüleme)
        public IActionResult Create()
        {
            return View();
        }

        // 3. EKLEME İŞLEMİ (Kaydetme)
        [HttpPost]
        public async Task<IActionResult> Create(Film film)
        {
            if (ModelState.IsValid)
            {
                _context.Add(film);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }

        // 4. SİLME İŞLEMİ
        public async Task<IActionResult> Delete(int id)
        {
            var film = await _context.Filmler.FindAsync(id);
            if (film != null)
            {
                _context.Filmler.Remove(film);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}