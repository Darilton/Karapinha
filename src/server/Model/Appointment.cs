namespace Model;

public class Appointment
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; } = null!;
    public ICollection<ServiceProfessionalAppointment>? ServiceProfessionalAppointments { get; set; }
    public AppointmentState state {get; set;}
    public float TotalPrice { get; set; } = 0;
}