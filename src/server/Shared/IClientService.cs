using DTO;
using Model;

namespace Shared;

public interface IClientService
{
    public Task<ClientDTO> AddClientAsync(ClientAddDTO client, ApplicationUser newUserDetails);
    public Task<ClientDTO> GetClientByIdAsync(string userId);
    public Task<IEnumerable<ClientDTO>> GetClientsAsync();
}
