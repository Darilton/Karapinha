using Microsoft.EntityFrameworkCore;

namespace Model;

[PrimaryKey(nameof(ServiceId), nameof(ProfessionalId), nameof(AppointmentId))]
public class ServiceProfessionalAppointment
{
    public int ProfessionalId { get; set; }
    public Professional Professional { get; set; } = null!;

    public int ServiceId { get; set; }
    public Service Service { get; set; } = null!;

    public int AppointmentId { get; set; }
    public Appointment Appointment { get; set; } = null!;

    public DateOnly date {get; set; }

    public int WorkingHourId { get; set; }
    public WorkingHour WorkingHour { get; set; } = null!;
    public float Price { get; set; } = 0;
}
