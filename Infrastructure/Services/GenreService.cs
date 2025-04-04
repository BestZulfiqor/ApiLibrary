using System.Net;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class GenreService(DataContext context) : IGenreService
{
    public async Task<Response<List<Genre>>> GetAllGenresAsync()
    {
        var genres = await context.Genres.ToListAsync();
        return new Response<List<Genre>>(genres);
    }

    public async Task<Response<Genre>> GetGenreById(int id)
    {
        var genre = await context.Genres.FindAsync(id);
        return genre == null
            ? new Response<Genre>(HttpStatusCode.BadRequest, "Genre not found")
            : new Response<Genre>(genre);
    }

    public async Task<Response<Genre>> CreateGenreAsync(Genre genre)
    {
        await context.Genres.AddAsync(genre);
        var result = await context.SaveChangesAsync();
        return result == 0
            ? new Response<Genre>(HttpStatusCode.BadRequest, "Genre not created")
            : new Response<Genre>(genre);
    }

    public async Task<Response<Genre>> UpdateGenreAsync(Genre genre)
    {
        context.Genres.Update(genre);
        var result = await context.SaveChangesAsync();
        return result == 0
            ? new Response<Genre>(HttpStatusCode.BadRequest, "Genre not updated")
            : new Response<Genre>(genre);
    }

    public async Task<Response<string>> DeleteGenreAsync(string id)
    {
        var genre = await context.Genres.FindAsync(id);
        if (genre == null)
        {
            return new Response<string>(HttpStatusCode.BadRequest, "Genre not found");
        }

        context.Genres.Remove(genre);
        var result = await context.SaveChangesAsync();
        return result == 0
            ? new Response<string>(HttpStatusCode.BadRequest, "Genre not deleted")
            : new Response<string>("Genre deleted successfully");
    }
}