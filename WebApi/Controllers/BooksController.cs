using Domain.Entities;
using Domain.Responses;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BooksController(IBookService service)
{
    [HttpGet]
    public async Task<Response<List<Book>>> GetAllBooksAsync()
    {
        return await service.GetAllBooksAsync();
    }
    
    [HttpGet("{id:int}")]
    public async Task<Response<Book>> GetBookByIdAsync(int id)
    {
        return await service.GetBookByIdAsync(id);
    }
    
    [HttpPost]
    public async Task<Response<Book>> CreateBookAsync(Book book)
    {
        return await service.CreateBookAsync(book);
    }
    
    [HttpPut]
    public async Task<Response<Book>> UpdateBookAsync(Book book)
    {
        return await service.UpdateBookAsync(book);
    }
    
    [HttpDelete]
    public async Task<Response<string>> DeleteBookAsync(string id)
    {
        return await service.DeleteBookAsync(id);
    }
}