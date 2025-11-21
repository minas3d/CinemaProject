using Cinema_project.DataAccess;
using Cinema_project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CinemaRepository : ICinemaRepository
{
    private readonly ApplicationDbContext _context;

    public CinemaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Cinema>> GetAllAsync()
    {
        return await _context.Cinemas.ToListAsync();
    }

    public async Task<Cinema> GetByIdAsync(int id)
    {
        return await _context.Cinemas.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(Cinema cinema)
    {
        _context.Cinemas.Add(cinema);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Cinema cinema)
    {
        _context.Cinemas.Update(cinema);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var cinema = await _context.Cinemas.FindAsync(id);
        if (cinema != null)
        {
            _context.Cinemas.Remove(cinema);
            await _context.SaveChangesAsync();
        }
    }
}
