using BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAPI;

public class DataContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DataContext()
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        //optionsBuilder.UseSqlServer("Server=217.160.100.56;User ID=sa;Password=;Database=Booksdb;TrustServerCertificate=True;Trusted_Connection=True;Integrated Security=false;");
        optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Booksdb;TrustServerCertificate=True;Trusted_Connection=True;");
    }
}