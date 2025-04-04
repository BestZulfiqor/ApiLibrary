using System.Net;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class BookService(DataContext context) : IBookService
{
    public async Task<Response<List<Book>>> GetAllBooksAsync()
    {
        var books = await context.Books.ToListAsync();
        return new Response<List<Book>>(books);
    }

    public async Task<Response<Book>> GetBookByIdAsync(int id)
    {
        var book = await context.Books.FindAsync();
        return book == null
            ? new Response<Book>(HttpStatusCode.NotFound, "Book not found")
            : new Response<Book>(book);
    }

    public async Task<Response<Book>> CreateBookAsync(Book book)
    {
        await context.Books.AddAsync(book);
        var result = await context.SaveChangesAsync();
        return result == 0
            ? new Response<Book>(HttpStatusCode.BadRequest, "Book not created")
            : new Response<Book>(book);
    }

    public async Task<Response<Book>> UpdateBookAsync(Book book)
    {
        context.Books.Update(book);
        var result = await context.SaveChangesAsync();
        return result == 0
            ? new Response<Book>(HttpStatusCode.BadRequest, "Book not updated")
            : new Response<Book>(book);
    }

    public async Task<Response<string>> DeleteBookAsync(string id)
    {
        var book = await context.Books.FindAsync(id);
        if (book == null)
        {
            return new Response<string>(HttpStatusCode.BadRequest, "Book not found");
        }

        context.Books.Remove(book);
        var result = await context.SaveChangesAsync();
        return result == 0
            ? new Response<string>(HttpStatusCode.BadRequest, "Book not deleted")
            : new Response<string>("Book deleted successfully");
    }
}