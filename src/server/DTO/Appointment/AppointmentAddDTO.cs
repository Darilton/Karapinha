namespace DTO;

public class AppointmentAddDTO
{
        public int ClientId { get; set; }
        public ICollection<ServiceProfessionalAppointmentDTO> ? ProfessionalAppointmentDTOs { get; set;}
}
