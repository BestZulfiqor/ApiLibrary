using System.Net;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AuthorService(DataContext context) : IAuthorService
{
    public async Task<Response<List<Author>>> GetAllAuthorsAsync()
    {
        var authors = await context.Authors.ToListAsync();
        return new Response<List<Author>>(authors);
    }

    public async Task<Response<Author>> GetAuthorByIdAsync(int id)
    {
        var author = await context.Authors.FindAsync(id);
        return author == null
            ? new Response<Author>(HttpStatusCode.NotFound, "Author not found")
            : new Response<Author>(author);
    }

    public async Task<Response<Author>> CreateAuthorAsync(Author author)
    {
        await context.Authors.AddAsync(author);
        var result = await context.SaveChangesAsync();
        
        return result == 0
            ? new Response<Author>(HttpStatusCode.BadRequest, "Author not created")
            : new Response<Author>(author);
    }

    public async Task<Response<Author>> UpdateAuthorAsync(Author author)
    {
        context.Authors.Update(author);
        var result = await context.SaveChangesAsync();
        
        return result == 0
            ? new Response<Author>(HttpStatusCode.BadRequest, "Author not updated")
            : new Response<Author>(author);
    }

    public async Task<Response<string>> DeleteAuthorAsync(string id)
    {
        var author = await context.Authors.FindAsync(id);
        if (author == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Author not found");
        }
        context.Authors.Remove(author);
        var result = await context.SaveChangesAsync();
        return result == 0
            ? new Response<string>(HttpStatusCode.BadRequest, "Author not deleted")
            : new Response<string>("Author deleted");
    }
}