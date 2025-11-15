using Cinema_project.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.Categories = _context.Categories.ToList();
        ViewBag.Cinemas = _context.Cinemas.ToList();

        var movies = _context.Movies
            .Include(m => m.Category)
            .Include(m => m.Cinema)
            .ToList();

        return View(movies);
    }
}
