using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Model;

public class Client 
{
    public int Id { get; set; }
    //it's information as user
    public string? ApplicationUserId { get; set; }
    public ApplicationUser? ApplicationUser { get; set; }
    public ICollection<Appointment>? Appointments{ get; set; }
}
