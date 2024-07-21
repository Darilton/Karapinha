using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Identity;
using Model;
using Shared;

namespace Service;

public class ProfessionalService : IProfessionalService
{
    private readonly IGenericRepository<Professional> repo;
    private readonly IGenericRepository<Category> categoryRepo;
    private readonly IGenericRepository<WorkingHour>  workingHourRepo;
    private readonly IMapper mapper;

    public ProfessionalService(IGenericRepository<WorkingHour> workingHourRepo, IGenericRepository<Category> categoryRepo, UserManager<ApplicationUser> userManager, IGenericRepository<Professional> repo, IMapper mapper)
    {
        this.categoryRepo = categoryRepo;
        this.repo = repo;
        this.mapper = mapper;
        this.workingHourRepo = workingHourRepo;
    }

    public async Task<ProfessionalDTO> AddProfessionalAsync(ProfessionalAddDTO professional, ApplicationUser newUserDetails)
    {
        Category category = await categoryRepo.GetByIdAsync(professional.CategoryId);
        if(category == null) return null!;


        List<WorkingHour> workingHours = new List<WorkingHour>();

        if(professional.WorkingHourIds != null)
        foreach(int workingHourId in professional.WorkingHourIds){
            WorkingHour workingHour =await workingHourRepo.GetByIdAsync(workingHourId);
            if(workingHour == null) return null!;

            workingHours.Add(workingHour);
        }


        Professional newProfessional = mapper.Map<Professional>(professional);
        
        newProfessional.Category = category;
        newProfessional.ApplicationUser = newUserDetails;
        newProfessional.WorkHours = workingHours;
        
        return mapper.Map<ProfessionalDTO>(await repo.InsertAsync(newProfessional));
    }

    public Task<bool> DeleteProfessionalAsync(int ProfessionalId)
    {
        throw new NotImplementedException();
    }

    public async Task<ProfessionalDTO> GetProfessionalByIdAsync(int professionalId)
    {
        Professional professional = await repo.GetByIdAsync(professionalId);
        if(professional == null) return null!;

        return mapper.Map<ProfessionalDTO>(professional);
    }

    public async Task<IEnumerable<ProfessionalDTO>> GetProfessionalsAsync()
    {
        List<ProfessionalDTO> professionals = new List<ProfessionalDTO>();

        foreach(Professional professional in await repo.GetAllAsync()){
            ProfessionalDTO professionalDTO = mapper.Map<ProfessionalDTO>(professional);
            professionalDTO.WorkHours = mapper.Map<WorkingHourDTO[]>(professional.WorkHours);
            professionals.Add(professionalDTO);
        }

        return professionals;
    }
}