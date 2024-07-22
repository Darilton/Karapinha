using DTO;
using Model;

namespace Shared;

public interface IServiceProfessionalAppointmentService
{
    public Task<(ICollection<ServiceProfessionalAppointment>, string)> CreateProfessionalAppointmentAsync(ICollection<ServiceProfessionalAppointmentDTO> serviceProfessionalAppointments);
    public Task AddList(ICollection<ServiceProfessionalAppointment> saps, int appointmentId);
}
