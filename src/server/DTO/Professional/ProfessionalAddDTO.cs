using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DTO;

public class ProfessionalAddDTO
{
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set;}

    [EmailAddress(ErrorMessage = "Please enter valid email")]
    public string? Email { get; set; }

    [Phone(ErrorMessage = "Please enter valid Telefone number")]
    public string? PhoneNumber { get; set; }
    
    [Length(minimumLength:14, maximumLength:14)]
    public string? Bilhete { get; set; }
    public int CategoryId { get; set; }
    [PasswordPropertyText]
    public string? Password { get; set; }
    public IEnumerable<int>? WorkingHourIds { get; set; }
}
