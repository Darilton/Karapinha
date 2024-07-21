using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Identity;
using Model;
using Shared;

namespace Service;

public class ClientService : IClientService
{
    private readonly IClientRepository clientRepository;
    private readonly IMapper mapper;

    public ClientService(IClientRepository clientRepository, IMapper mapper){
        this.clientRepository = clientRepository;
        this.mapper = mapper;
    }

    public async Task<ClientDTO> AddClientAsync(ClientAddDTO newClient, ApplicationUser newUserDetails)
    {
        Client client = mapper.Map<Client>(newClient);
        client.ApplicationUser = newUserDetails;

        await clientRepository.InsertAsync(client);
        return mapper.Map<ClientDTO>(client);
    }

    public async Task<bool> DeleteClientAsync(int clientId)
    {
        Client client = await clientRepository.GetByIdAsync(clientId);

        if(client == null) return false;

        await clientRepository.DeleteByIdAsync(clientId);
        return true;
    }

    public async Task<ClientDTO> GetClientByIdAsync(int clientId)
    {
        Client client = await clientRepository.GetClientWithInclude(clientId);

        if(client == null) return null!;

        return mapper.Map<ClientDTO>(client);
    }

    public async Task<IEnumerable<ClientDTO>> GetClientsAsync()
    {
        List<ClientDTO> clients = new List<ClientDTO>();

        foreach (Client client in await clientRepository.GetClientsWithInclude()){
            clients.Add(mapper.Map<ClientDTO>(client));
            if(client.ApplicationUser != null)
                Console.WriteLine(client.ApplicationUser.UserName);
        }
        
        return clients;
    }
}