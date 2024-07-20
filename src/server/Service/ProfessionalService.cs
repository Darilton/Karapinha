using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Identity;
using Model;
using Shared;

namespace Service;

public class ProfessionalService : IProfessionalService
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly IGenericRepository<Professional> repo;
    private readonly IGenericRepository<Category> categoryRepo;
    private readonly IMapper mapper;

    public ProfessionalService(IGenericRepository<Category> categoryRepo, UserManager<ApplicationUser> userManager, IGenericRepository<Professional> repo, IMapper mapper)
    {
        this.categoryRepo = categoryRepo;
        this.repo = repo;
        this.userManager = userManager;
        this.mapper = mapper;
    }

    public async Task<Tuple<ProfessionalDTO, string>> AddProfessional(ProfessionalAddDTO professional, byte[] image)
    {
        ApplicationUser user = mapper.Map<ApplicationUser>(professional);

        Category category = await categoryRepo.GetByIdAsync(professional.categoryId);
        if(category == null)
            return new Tuple<ProfessionalDTO, string>(null!, "Could not add professional because category does not exists");

        user.Image = new Image(){
            Photo = image,
            Description = user.FirstName + "profile picture"
        };

        var res = await userManager.CreateAsync(user, professional.Password!);
        if(!res.Succeeded){
            string err = "";
            foreach (var s in res.Errors)
            {
                err = new String(s.Description.ToArray<char>()) + "\n";
            }
            return new Tuple<ProfessionalDTO, string>(null!, new string(err.ToArray<char>()));
        }
        
        await userManager.AddToRoleAsync(user, "professional");

        Professional newProfessional = new Professional(){
            userInfo = user,
            Category = category
        };

        newProfessional = await repo.InsertAsync(newProfessional);
        
        if(professional == null)
            return new Tuple<ProfessionalDTO, string>(null!, "Could not add new Professional. Please try again");
        
        return new Tuple<ProfessionalDTO, string>(mapper.Map<ProfessionalDTO>(newProfessional), "");
    }
}