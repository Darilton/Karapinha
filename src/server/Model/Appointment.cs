using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class Appointment
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    
    [ForeignKey("Client")]
    public string? ClientId { get; set; }
    public Client Client { get; set; } = null!;
    ICollection<ServiceProfessionalAppointment>? ServiceProfessionalAppointments { get; set; }
}