using Domain.Entities;
using Domain.Responses;

namespace Infrastructure;

public interface IBookService
{
    Task<Response<List<Book>>> GetAllBooksAsync();
    Task<Response<Book>> GetBookByIdAsync(int id);
    Task<Response<Book>> CreateBookAsync(Book book);
    Task<Response<Book>> UpdateBookAsync(Book book);
    Task<Response<string>> DeleteBookAsync(string id);
}