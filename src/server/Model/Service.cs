using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model;

public class Service
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public float Price { get; set; }

    public int CategoryId { get; set; }
    [JsonIgnore]
    public Category? Category { get; set; }
}
