using Domain.Entities;
using Domain.Responses;

namespace Infrastructure;

public interface IAuthorService
{
    Task<Response<List<Author>>> GetAllAuthorsAsync();
    Task<Response<Author>> GetAuthorByIdAsync(int id);
    Task<Response<Author>> CreateAuthorAsync(Author author);
    Task<Response<Author>> UpdateAuthorAsync(Author author);
    Task<Response<string>> DeleteAuthorAsync(string id);
}