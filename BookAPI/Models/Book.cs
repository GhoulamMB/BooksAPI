using System.Text.Json.Serialization;

namespace BookAPI.Models;

public class Book
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Description { get; set; }
    public int Year { get; set; }
}