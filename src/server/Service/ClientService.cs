using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Identity;
using Model;
using Shared;

namespace Service;

public class ClientService : IClientService
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly IMapper mapper;

    public ClientService(UserManager<ApplicationUser> userManager, IMapper mapper){
        this.userManager = userManager;
        this.mapper = mapper;
    }

    public async Task<ClientDTO> AddClient(ClientAddDTO client, byte[] clientPicture)
    {
        
        return new ClientDTO(){};
    }

    public async Task<ClientDTO?> GetClientByIdAsync(string clientId)
    {
        ApplicationUser? user = await userManager.FindByIdAsync(clientId);
        if(user == null)
            return null!;

        return mapper.Map<ClientDTO?>(user);
    }
}