using System.ComponentModel.DataAnnotations;

namespace Model;

public class Professional : ApplicationUser
{
    //A professional can working at different hours during the
    public ICollection<WorkingHour>? WorkHours { get; set; }

    //A professional belongs to a category
    public int CategoryId { get; set; }
    public Category Category{ get; set; } = null!;
}
