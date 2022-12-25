using System.Text.Json.Serialization;

namespace BookAPI.Models;

public class BookRequest : Book
{
    [JsonIgnore]
    public override int Id { get; set; }
}