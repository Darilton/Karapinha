using DTO;

namespace DTO;

public class AppointmentDTO
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public ICollection<ServiceProfessionalAppointmentDTO> ? ServiceProfessionalAppointments { get; set;}
    public float TotalPrice { get; set; } = 0;
}
