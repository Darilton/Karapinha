using AutoMapper;
using Data;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Model;
using Service;
using Shared;

namespace API;

[ApiController]
[Route("[controller]")]
public class ClientController :  ControllerBase
{
    private readonly IClientService clientService; 
    private readonly IUserService userService;
    private readonly IFileService fileService;
    private readonly IMapper mapper;

    public ClientController(IMapper mapper, IFileService fileService, IClientService clientService, IUserService userService){
        this.clientService = clientService;
        this.fileService = fileService;
        this.userService = userService;
        this.mapper = mapper;
    } 

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<ApplicationUser>> AddClient([FromForm]UserAddDTO client, IFormFile image){
        ApplicationUser user = mapper.Map<ApplicationUser>(client);

        user.Image = new Image(){
            Description = user.FirstName + "'s profile picture",
            Photo = fileService.ToByteArray(image)
        };

        var res = await userService.AddUserAsync(user, "client", client.Password!);
        if(!res.Succeeded){
            return BadRequest(res.Errors);
        } 

        ClientAddDTO newClient = mapper.Map<ClientAddDTO>(client);
        ClientDTO newUser = await clientService.AddClientAsync(newClient, user);
        return Ok(newUser);
    }
    // [HttpGet("userId/image")]
    // public async Task<ActionResult<IFileHttpResult>> GetUserPhoto(string userId){
    //     ClientDTO? client = await clientService.GetClientByIdAsync(userId);

    //     if(client == null)
    //         return NotFound();
        
    //     Image userPhoto = await imageRepository.GetByIdAsync(client.ImageId);

    //     if(userPhoto == null)
    //         return NotFound();

    //     return File(userPhoto.Photo,"image/jpeg");
    // }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApplicationUser>>> Get(){
        return Ok(await clientService.GetClientsAsync());
    }

    // [HttpGet("id")]
    // public async Task<ActionResult<ApplicationUser>> Get(string userId){
    //     ApplicationUser? user = await userService.GetUserByIdAsync(userId);
    //     if(user == null) return NotFound();

    //     return Ok(user);
    // }

    [HttpDelete]
    public async Task<ActionResult> Delete(string userId){
        var res = await userService.RemoveUserAsync(userId);
        
        if(!res.Succeeded) return NotFound("User Not Found");

        return Ok();
    }
}
