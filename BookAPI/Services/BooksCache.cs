using BookAPI.Models;

namespace BookAPI.Services;

public class BooksCache : IBooksCache
{
    public Dictionary<int,Book> Books { get; set; }

    private Timer _timer;

    public BooksCache()
    {
        Books = new();
        _timer = new Timer(CleanUp, null, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1));
    }
    public BooksCache(List<Book> books)
    {
        Books = books.ToDictionary(b => b.Id, b => b);
        _timer = new Timer(CleanUp, null, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1));
    }

    private void CleanUp(object? state)
    {
        Books.Clear();
    }
}