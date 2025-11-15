using Cinema_project.DataAccess;
using Cinema_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace Cinema_project.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoriesController(ApplicationDbContext context) => _context = context;
        public async Task<IActionResult> Index() => View(await _context.Categories.ToListAsync());
        public IActionResult Create() => View();
        [HttpPost][ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category model)
        {
            if (!ModelState.IsValid) return View(model);
            _context.Categories.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var cat = await _context.Categories.FindAsync(id);
            if (cat == null) return NotFound();
            return View(cat);
        }
        [HttpPost][ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category model)
        {
            if (!ModelState.IsValid) return View(model);
            _context.Categories.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var cat = await _context.Categories.FindAsync(id);
            if (cat == null) return NotFound();
            return View(cat);
        }
        [HttpPost, ActionName("Delete")][ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cat = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(cat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
