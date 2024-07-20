using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model;
using Shared;

namespace Service;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly RoleManager<IdentityRole> roleManager;

    public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager){
        this.userManager = userManager;
        this.roleManager = roleManager;
    }

    public async Task<IdentityResult> AddUserAsync(ApplicationUser user, string role, string password)
    {
        var res = await userManager.CreateAsync(user, password);
        if(!res.Succeeded)
            return res;

        if(! await roleManager.RoleExistsAsync(role)){
            await userManager.DeleteAsync(user);
            return IdentityResult.Failed();
        }

        res = await userManager.AddToRoleAsync(user, role);
        
        return res;
    }

    public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
    {
        return await userManager.Users.ToListAsync();
    }

    public async Task<ApplicationUser?> GetUserByIdAsync(string userId)
    {
        return await userManager.FindByIdAsync(userId);
    }

    public async Task<IdentityResult> RemoveUserAsync(string userId)
    {
        ApplicationUser? user = await userManager.FindByIdAsync(userId);

        if(user == null) return IdentityResult.Failed();

        return await userManager.DeleteAsync(user);
    }
}
