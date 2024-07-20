using DTO;
using Microsoft.AspNetCore.Identity;
using Model;

namespace Shared;

public interface IUserService
{
    public Task<IdentityResult> AddUserAsync(ApplicationUser user, string role, string password);
    public Task<ApplicationUser?> GetUserByIdAsync(string userId);
    public Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
    public Task<IdentityResult> RemoveUserAsync(string userId);
}
