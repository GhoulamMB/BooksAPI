using BookAPI.Models;
using BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _bookService.GetAll();
        }

        [HttpGet("{id:int}")]
        public async Task<Book?> GetBook(int id)
        {
            return await _bookService.Get(id);
        }
        [HttpPost]
        public async Task AddBook(List<Book> book)
        {
            await _bookService.Add(book);
        }

        [HttpDelete("{id:int}")]
        public async Task<IEnumerable<Book>> Delete(int id)
        {
            return await _bookService.Delete(id);
        }
    }
}