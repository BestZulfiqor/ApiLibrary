using Domain.Entities;
using Domain.Responses;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthorsController(IAuthorService service)
{
    [HttpGet]
    public async Task<Response<List<Author>>> GetAllAuthorsAsync()
    {
        return await service.GetAllAuthorsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<Response<Author>> GetAuthorByIdAsync(int id)
    {
        return await service.GetAuthorByIdAsync(id);
    }

    [HttpPost]
    public async Task<Response<Author>> CreateAuthorAsync(Author author)
    {
        return await service.CreateAuthorAsync(author);
    }

    [HttpPut]
    public async Task<Response<Author>> UpdateAuthorAsync(Author author)
    {
        return await service.UpdateAuthorAsync(author);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteAuthorAsync(string id)
    {
        return await service.DeleteAuthorAsync(id);
    }
}