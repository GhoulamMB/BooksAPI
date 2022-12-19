using BookAPI.Models;

namespace BookAPI.Services;

public interface IBookService
{
    Task<IEnumerable<Book>> GetAll();
    Task<Book?> Get(int id);
    Task Add(List<Book> book);
    Task<List<Book>> Delete(int id);
}