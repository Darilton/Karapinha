using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Identity;
using Model;
using Shared;

namespace Service;

public class ClientService : IClientService
{
    private readonly IGenericRepository<Client> clientRepository;
    private readonly IMapper mapper;

    public ClientService(IGenericRepository<Client> clientRepository, IMapper mapper){
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

    public Task<ClientDTO> GetClientByIdAsync(string clientId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ClientDTO>> GetClientsAsync()
    {
        List<ClientDTO> clients = new List<ClientDTO>();

        foreach (Client client in await clientRepository.GetAllAsync()){
            clients.Add(mapper.Map<ClientDTO>(client));
            if(client.ApplicationUser != null)
                Console.WriteLine(client.ApplicationUser.UserName);
        }
        
        return clients;
    }
}