using System.Text.Json.Serialization;

namespace BookAPI.Models;

public class Book
{
    public virtual int Id { get; set; } = default;
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Description { get; set; }
    public int Year { get; set; }
}