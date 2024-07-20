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
        client.userInfo = newUserDetails;

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
            if(client.userInfo != null)
                Console.WriteLine("Chegour aqui");
        }
        
        return clients;
    }
}