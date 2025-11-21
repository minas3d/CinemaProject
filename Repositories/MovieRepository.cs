using Cinema_project.DataAccess;
using Cinema_project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class MovieRepository : IMovieRepository
{
    private readonly ApplicationDbContext _context;

    public MovieRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Movie>> GetAllAsync()
    {
        return await _context.Movies
            .Include(m => m.Category)
            .Include(m => m.Cinema)
            .ToListAsync();
    }

    public async Task<Movie> GetByIdAsync(int id)
    {
        return await _context.Movies
            .Include(m => m.Category)
            .Include(m => m.Cinema)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task AddAsync(Movie movie)
    {
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Movie movie)
    {
        _context.Movies.Update(movie);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie != null)
        {
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }
}
