using System.ComponentModel.DataAnnotations;

namespace Model;

public class WorkingHour
{
    public int Id { get; set; }
    
    [Required]
    public TimeOnly Hour { get; set; }
}
