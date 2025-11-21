using Cinema_project.DataAccess;
using Cinema_project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ActorRepository : IActorRepository
{
    private readonly ApplicationDbContext _context;

    public ActorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Actor>> GetAllAsync()
    {
        return await _context.Actors
            .Include(a => a.MovieActors)
            .ThenInclude(ma => ma.Movie)
            .ToListAsync();
    }

    public async Task<Actor> GetByIdAsync(int id)
    {
        return await _context.Actors
            .Include(a => a.MovieActors)
            .ThenInclude(ma => ma.Movie)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task AddAsync(Actor actor)
    {
        _context.Actors.Add(actor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Actor actor)
    {
        _context.Actors.Update(actor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var actor = await _context.Actors.FindAsync(id);
        if (actor != null)
        {
            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
        }
    }
}
