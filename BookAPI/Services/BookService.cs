using BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Services;
public class BookService : IBookService
{
    private readonly DataContext _context;
    private BooksCache _cache;
    public BookService()
    {
        _context = new DataContext();
        //Cache data
        _cache = new(_context.Books.ToList());
    }
    public List<Book> GetAll()
    {
        return _cache.Books.Values.ToList();
    }

    public Book Get(int id)
    {
        return _cache.Books[id];
    }

    public async Task Add(List<Book> book)
    {
        await _context.Books.AddRangeAsync(book.ToHashSet());
        await _context.SaveChangesAsync();
        _cache.Books = await _context.Books.ToDictionaryAsync(b=>b.Id,b=>b);
    }

    public async Task<bool> Delete(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book is not null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            _cache.Books = await _context.Books.ToDictionaryAsync(b=>b.Id,b=>b);
            return true;
        }
        return false;
    }
}