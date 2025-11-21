using Cinema_project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

public class ActorsController : Controller
{
    private readonly IActorRepository _actorRepo;

    public ActorsController(IActorRepository actorRepo)
    {
        _actorRepo = actorRepo;
    }

    public async Task<IActionResult> Index()
    {
        var actors = await _actorRepo.GetAllAsync();
        return View(actors);
    }

    public async Task<IActionResult> Details(int id)
    {
        var actor = await _actorRepo.GetByIdAsync(id);
        if (actor == null) return NotFound();
        return View(actor);
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Actor actor)
    {
        if (!ModelState.IsValid) return View(actor);
        await _actorRepo.AddAsync(actor);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var actor = await _actorRepo.GetByIdAsync(id);
        if (actor == null) return NotFound();
        return View(actor);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Actor actor)
    {
        if (!ModelState.IsValid) return View(actor);
        await _actorRepo.UpdateAsync(actor);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var actor = await _actorRepo.GetByIdAsync(id);
        if (actor == null) return NotFound();
        return View(actor);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _actorRepo.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
