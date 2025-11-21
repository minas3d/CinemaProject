using Cinema_project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IActorRepository
{
    Task<List<Actor>> GetAllAsync();
    Task<Actor> GetByIdAsync(int id);
    Task AddAsync(Actor actor);
    Task UpdateAsync(Actor actor);
    Task DeleteAsync(int id);
}
