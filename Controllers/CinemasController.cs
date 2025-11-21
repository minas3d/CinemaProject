using Cinema_project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

public class CinemasController : Controller
{
    private readonly ICinemaRepository _cinemaRepo;

    public CinemasController(ICinemaRepository cinemaRepo)
    {
        _cinemaRepo = cinemaRepo;
    }

    public async Task<IActionResult> Index()
    {
        var cinemas = await _cinemaRepo.GetAllAsync();
        return View(cinemas);
    }

    public async Task<IActionResult> Details(int id)
    {
        var cinema = await _cinemaRepo.GetByIdAsync(id);
        if (cinema == null) return NotFound();
        return View(cinema);
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Cinema cinema)
    {
        if (!ModelState.IsValid) return View(cinema);
        await _cinemaRepo.AddAsync(cinema);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var cinema = await _cinemaRepo.GetByIdAsync(id);
        if (cinema == null) return NotFound();
        return View(cinema);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Cinema cinema)
    {
        if (!ModelState.IsValid) return View(cinema);
        await _cinemaRepo.UpdateAsync(cinema);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var cinema = await _cinemaRepo.GetByIdAsync(id);
        if (cinema == null) return NotFound();
        return View(cinema);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _cinemaRepo.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
