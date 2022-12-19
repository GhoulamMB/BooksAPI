using BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Services;
public class BookService : IBookService
{
    private readonly DataContext? _context;
    private IList<Book> _booksCache;
    public BookService()
    {
        _context = new DataContext();
        _booksCache = _context.Books.ToList();
    }
    public Task<IEnumerable<Book>> GetAll()
    {
        //var books = await _context!.Books.ToListAsync();
        return Task.FromResult<IEnumerable<Book>>(_booksCache);
    }

    public Task<Book?> Get(int id)
    {
        var result = _booksCache.First(x => x.Id == id);
        return Task.FromResult<Book?>(result);
    }

    public async Task Add(List<Book> book)
    {
        await _context!.Books.AddRangeAsync(book.ToHashSet());
        await _context.SaveChangesAsync();
        _booksCache = await _context.Books.ToListAsync();
    }

    public async Task<List<Book>> Delete(int id)
    {
        var book = await _context!.Books.FindAsync(id);
        if (book is null)
        {
            return (List<Book>)Enumerable.Empty<Book>();
        }
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        _booksCache = await _context.Books.ToListAsync();
        return await _context.Books.ToListAsync();
    }
}