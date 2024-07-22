using System.ComponentModel.DataAnnotations;

namespace DTO;

public class ServiceProfessionalAppointmentDTO
{
    public int ProfessionalId { get; set; }
    public int ServiceId { get; set; }
    public int AppointmentId { get; set; }
    public DateDTO? date {get; set; }
    public int WorkingHourId { get; set; }
    [Range(0, int.MaxValue)]
    public float Price { get; set; } = 0;
}
