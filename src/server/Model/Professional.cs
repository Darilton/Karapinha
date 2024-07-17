using System.ComponentModel.DataAnnotations;

namespace Model;

public class Professional
{
    public int Id { get; set; }
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Bilhete { get; set; }
    [Required]
    public string? PhoneNumber { get; set; }

    //A professional can working at different hours during the
    public ICollection<WorkingHour>? WorkHours { get; set; }

    //A professional must have an image
    public int ImageId { get; set; }
    public Image Image { get; set; } = null!;

    //A professional belongs to a category
    public int CategoryId { get; set; }
    public Category Category{ get; set; } = null!;
}
