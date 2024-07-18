using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class Client 
{
    public int Id { get; set; }
    //it's information as user
    public string? ApplicationUserId { get; set; }
    public ApplicationUser? userInfo{ get; set; }
    public ICollection<Appointment>? Appointments{ get; set; }
}
