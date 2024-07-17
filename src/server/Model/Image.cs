using System.ComponentModel.DataAnnotations;

namespace Model;

public class Image
{
    public int Id { get; set; }
    [Required]
    public string? Description { get; set; }
    public byte[] Photo { get; set; } = null!;
}
