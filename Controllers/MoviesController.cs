using Cinema_project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

public class MoviesController : Controller
{
    private readonly IMovieRepository _movieRepo;

    public MoviesController(IMovieRepository movieRepo)
    {
        _movieRepo = movieRepo;
    }

    public async Task<IActionResult> Index()
    {
        var movies = await _movieRepo.GetAllAsync();
        return View(movies);
    }

    public async Task<IActionResult> Details(int id)
    {
        var movie = await _movieRepo.GetByIdAsync(id);
        if (movie == null) return NotFound();
        return View(movie);
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Movie movie)
    {
        if (!ModelState.IsValid) return View(movie);
        await _movieRepo.AddAsync(movie);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var movie = await _movieRepo.GetByIdAsync(id);
        if (movie == null) return NotFound();
        return View(movie);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Movie movie)
    {
        if (!ModelState.IsValid) return View(movie);
        await _movieRepo.UpdateAsync(movie);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var movie = await _movieRepo.GetByIdAsync(id);
        if (movie == null) return NotFound();
        return View(movie);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _movieRepo.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
