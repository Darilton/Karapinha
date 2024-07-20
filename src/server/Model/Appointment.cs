namespace Model;

public class Appointment
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; } = null!;
    ICollection<ServiceProfessionalAppointment>? ServiceProfessionalAppointments { get; set; }
}