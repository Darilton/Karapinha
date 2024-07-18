using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class Professional
{
    public int Id { get; set; }
    //A professional can working at different hours during the
    public ICollection<WorkingHour>? WorkHours { get; set; }


    //it's information as user
    public string? ApplicationUserId { get; set; }
    public ApplicationUser? userInfo{ get; set; }

    //A professional belongs to a category
    public int CategoryId { get; set; }
    public Category Category{ get; set; } = null!;
}
