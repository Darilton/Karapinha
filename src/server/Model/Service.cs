using System.Text.Json.Serialization;

namespace Model;

public class Service
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public int CategoryId { get; set; }
    [JsonIgnore]
    public Category? Category { get; set; }
}
