using Domain.Entities;
using Domain.Responses;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class GenresController(IGenreService service)
{
    [HttpGet]
    public async Task<Response<List<Genre>>> GetAllGenresAsync()
    {
        return await service.GetAllGenresAsync();
    }
    
    [HttpGet("{id:int}")]
    public async Task<Response<Genre>> GetGenreById(int id)
    {
        return await service.GetGenreById(id);
    }
    
    [HttpPost]
    public async Task<Response<Genre>> CreateGenreAsync(Genre genre)
    {
        return await service.CreateGenreAsync(genre);
    }
    
    [HttpPut]
    public async Task<Response<Genre>> UpdateGenreAsync(Genre genre)
    {
        return await service.UpdateGenreAsync(genre);
    }
    
    [HttpDelete]
    public async Task<Response<string>> DeleteGenreAsync(string id)
    {
        return await service.DeleteGenreAsync(id);
    }
}