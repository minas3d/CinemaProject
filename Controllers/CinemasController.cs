using Cinema_project.DataAccess;
using Cinema_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace Cinema_project.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CinemasController(ApplicationDbContext context) => _context = context;
        public async Task<IActionResult> Index() => View(await _context.Cinemas.ToListAsync());
        public IActionResult Create() => View();
        [HttpPost][ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cinema model)
        {
            if (!ModelState.IsValid) return View(model);
            _context.Cinemas.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await _context.Cinemas.FindAsync(id);
            if (cinema == null) return NotFound();
            return View(cinema);
        }
        [HttpPost][ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Cinema model)
        {
            if (!ModelState.IsValid) return View(model);
            _context.Cinemas.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var cinema = await _context.Cinemas.FindAsync(id);
            if (cinema == null) return NotFound();
            return View(cinema);
        }
        [HttpPost, ActionName("Delete")][ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinema = await _context.Cinemas.FindAsync(id);
            _context.Cinemas.Remove(cinema);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
