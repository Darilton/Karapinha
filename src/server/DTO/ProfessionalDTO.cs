namespace DTO;

public class ProfessionalDTO
{
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set;}
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Bilhete { get; set; }
    public int categoryId { get; set; }
    public int ImageId { get; set; }

    public ICollection<WorkingHourDTO>? WorkHours{ get; set; }
}
