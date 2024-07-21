using DTO;
using Model;

namespace Shared;

public interface IClientService
{
    public Task<ClientDTO> AddClientAsync(ClientAddDTO client, ApplicationUser newUserDetails);
    public Task<ClientDTO> GetClientByIdAsync(int clientId);
    public Task<IEnumerable<ClientDTO>> GetClientsAsync();
    public Task<bool> DeleteClientAsync(int clientId);
}
