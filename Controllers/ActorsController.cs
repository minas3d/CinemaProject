using Cinema_project.DataAccess;
using Cinema_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace Cinema_project.Controllers
{
    public class ActorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ActorsController(ApplicationDbContext context) => _context = context;
        public async Task<IActionResult> Index() => View(await _context.Actors.ToListAsync());
        public async Task<IActionResult> Details(int id)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);
            if (actor == null) return NotFound();
            return View(actor);
        }
        public IActionResult Create() => View();
        [HttpPost][ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Actor model)
        {
            if (!ModelState.IsValid) return View(model);
            _context.Actors.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var actor = await _context.Actors.FindAsync(id);
            if (actor == null) return NotFound();
            return View(actor);
        }
        [HttpPost][ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Actor model)
        {
            if (!ModelState.IsValid) return View(model);
            _context.Actors.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var actor = await _context.Actors.FindAsync(id);
            if (actor == null) return NotFound();
            return View(actor);
        }
        [HttpPost, ActionName("Delete")][ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actor = await _context.Actors.FindAsync(id);
            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
