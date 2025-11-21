using Cinema_project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IMovieRepository
{
    Task<List<Movie>> GetAllAsync();
    Task<Movie> GetByIdAsync(int id);
    Task AddAsync(Movie movie);
    Task UpdateAsync(Movie movie);
    Task DeleteAsync(int id);
}