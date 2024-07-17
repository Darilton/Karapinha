using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace Model;

public class ApplicationUser : IdentityUser
{
    [Required]
    [PersonalData]
    public string? FirstName { get; set; }
    [Required]
    [PersonalData]
    public string? LastName { get; set; }
    [Required]
    [PersonalData]
    public string? Bilhete { get; set; }
    [PersonalData]
    public int ImageId { get; set; }
    public Image Image { get; set; } = null!;
}