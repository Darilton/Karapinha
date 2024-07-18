using DTO;
using Model;

namespace Shared;

public interface IUserService
{
    public Task<UserDTO> AddUser(UserAddDTO user, string role, Byte[] userPhoto);
    public Task<ApplicationUser?> GetUserByIdAsync(string userId);
}
