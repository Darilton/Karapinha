using DTO;
using Microsoft.AspNetCore.Identity;
using Model;

namespace Shared;

public interface IProfessionalService
{
    public Task<ProfessionalDTO> AddProfessionalAsync(ProfessionalAddDTO Professional, ApplicationUser newUserDetails);
    public Task<ProfessionalDTO> GetProfessionalByIdAsync(int ProfessionalId);
    public Task<IEnumerable<ProfessionalDTO>> GetProfessionalsAsync();
    public Task<bool> DeleteProfessionalAsync(int ProfessionalId);
}
