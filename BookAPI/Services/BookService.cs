using BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Services;
public class BookService : IBookService
{
    private readonly DataContext _context;
    private List<Book> _booksCache;
    public BookService()
    {
        _context = new DataContext();
        //Cache data
        _booksCache = _context.Books.ToList();
    }
    public List<Book> GetAll()
    {
        return _booksCache;
    }

    public Book Get(int id)
    {
        return _booksCache.First(x => x.Id == id);
    }

    public async Task Add(List<Book> book)
    {
        await _context.Books.AddRangeAsync(book.ToHashSet());
        await _context.SaveChangesAsync();
        _booksCache = await _context.Books.ToListAsync();
    }

    public async Task<List<Book>> Delete(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book is not null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            _booksCache = await _context.Books.ToListAsync();
            return _booksCache.ToList();
        }

        return Enumerable.Empty<Book>().ToList();
    }
}