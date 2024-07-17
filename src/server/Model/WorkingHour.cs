using System.ComponentModel.DataAnnotations;

namespace Model;

public class WorkingHour
{
    public int Id { get; set; }
    
    [Required]
    public string? Hour { get; set; }
}
