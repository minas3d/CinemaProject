using Cinema_project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICinemaRepository
{
    Task<List<Cinema>> GetAllAsync();
    Task<Cinema> GetByIdAsync(int id);
    Task AddAsync(Cinema cinema);
    Task UpdateAsync(Cinema cinema);
    Task DeleteAsync(int id);
}
