using BookAPI.Models;

namespace BookAPI.Services;

public class BooksCache : IBooksCache
{
    public Dictionary<int,Book> Books { get; set; }

    public BooksCache()
    {
        Books = new();
    }
    public BooksCache(List<Book> books)
    {
        Books = books.ToDictionary(b => b.Id, b => b);
    }
}