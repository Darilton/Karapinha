using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Identity;
using Model;
using Shared;

namespace Service;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly IMapper mapper;

    public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper){
        this.userManager = userManager;
        this.roleManager = roleManager;
        this.mapper = mapper;
    }
    public async Task<UserDTO> AddUser(UserAddDTO user, string role, Byte[] userPhoto)
    {
        ApplicationUser newUser = mapper.Map<ApplicationUser>(user);
        newUser.Image = new Image(){
            Photo = userPhoto,
            Description = user.FirstName + "Profie Image"
        };


        var res = await userManager.CreateAsync(newUser, user.Password!);
        if(!res.Succeeded)
            return null!;

        bool roleExists = await roleManager.RoleExistsAsync(role);
        if(!roleExists)
            return null!;

        res = await userManager.AddToRoleAsync(newUser, "client");

        if(!res.Succeeded)
            return null!;
        
        return mapper.Map<UserDTO>(newUser);            
    }

    Task<ApplicationUser?> IUserService.GetUserByIdAsync(string userId)
    {
        return userManager.FindByIdAsync(userId);
    }
}
