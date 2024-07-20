using DTO;
using Microsoft.AspNetCore.Identity;
using Model;

namespace Shared;

public interface IProfessionalService
{
    public Task<Tuple<ProfessionalDTO, string>> AddProfessional(ProfessionalAddDTO professional, byte[] image);
}
