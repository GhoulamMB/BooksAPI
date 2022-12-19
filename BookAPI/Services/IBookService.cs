using BookAPI.Models;

namespace BookAPI.Services;

public interface IBookService
{
    List<Book> GetAll();
    Book? Get(int id);
    Task Add(List<Book> book);
    Task<List<Book>> Delete(int id);
}