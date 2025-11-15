using Cinema_project.DataAccess;
using Cinema_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cinema_project.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var movies = await _context.Movies
                .Include(m => m.Category)
                .Include(m => m.Cinema)
                .ToListAsync();

            return View(movies);
        }

        
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Cinemas = _context.Cinemas.ToList();

            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories.ToList();
                ViewBag.Cinemas = _context.Cinemas.ToList();
                return View(movie);
            }

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
                return NotFound();

            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Cinemas = _context.Cinemas.ToList();

            return View(movie);
        }

         
        [HttpPost]
        public async Task<IActionResult> Edit(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories.ToList();
                ViewBag.Cinemas = _context.Cinemas.ToList();
                return View(movie);
            }

            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

         public async Task<IActionResult> Details(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.Category)
                .Include(m => m.Cinema)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return View(movie);
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.Category)
                .Include(m => m.Cinema)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return View(movie);
        }

         [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
