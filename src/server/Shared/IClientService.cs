using DTO;

namespace Shared;

public interface IClientService
{
    public Task<ClientDTO> AddClient(ClientAddDTO client, byte[] clientPicture);
    public Task<ClientDTO?> GetClientByIdAsync(string userId);
}
