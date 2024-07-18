using Microsoft.EntityFrameworkCore;

namespace Model;

[PrimaryKey(nameof(ServiceId), nameof(ProfessionalId), nameof(AppointmentId))]
public class ServiceProfessionalAppointment
{
    public string? ProfessionalId { get; set; }
    public Professional Professional { get; set; } = null!;

    public int ServiceId { get; set; }
    public Service Service { get; set; } = null!;

    public int AppointmentId { get; set; }
    public Appointment Appointment { get; set; } = null!;
}
