using AutoMapper;
using Data;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Service;
using Shared;

namespace API;

[ApiController]
[Route("[controller]")]
public class UserController :  ControllerBase
{
    private readonly IClientService clientService; 
    private readonly IGenericRepository<Image> imageRepository;

    public UserController(IClientService clientService, IGenericRepository<Image> imageRepository){
        this.clientService = clientService;
        this.imageRepository = imageRepository;
    } 

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<ApplicationUser>> AddClient([FromForm]ClientAddDTO client, IFormFile image){
        byte[] userImage;
        using (var ms = new MemoryStream())
        {
            image.CopyTo(ms);
            userImage = ms.ToArray();
        }
        ClientDTO newClient = await clientService.AddClient(client, userImage);

        if (newClient == null)
            return BadRequest();

        return Ok(newClient);
    }
    [HttpGet("userId/image")]
    public async Task<ActionResult<IFileHttpResult>> Get(string userId){
        ClientDTO? client = await clientService.GetClientByIdAsync(userId);

        if(client == null)
            return NotFound();
        
        Image userPhoto = await imageRepository.GetByIdAsync(client.ImageId);

        if(userPhoto == null)
            return NotFound();

        return File(userPhoto.Photo,"image/jpeg");
    }
}
