using Domain.Entities;
using Domain.Responses;

namespace Infrastructure;

public interface IGenreService
{
    Task<Response<List<Genre>>> GetAllGenresAsync();
    Task<Response<Genre>> GetGenreById(int id);
    Task<Response<Genre>> CreateGenreAsync(Genre genre);
    Task<Response<Genre>> UpdateGenreAsync(Genre genre);
    Task<Response<string>> DeleteGenreAsync(string id);
}