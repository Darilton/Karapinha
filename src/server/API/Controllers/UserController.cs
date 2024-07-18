using AutoMapper;
using Data;
using DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Shared;

namespace API;

[ApiController]
[Route("[controller]")]
public class UserController :  ControllerBase
{
    private readonly UserManager<ApplicationUser> userManager; 
    private readonly IMapper mapper;

    public UserController(UserManager<ApplicationUser> userManager, IMapper mapper){
        this.userManager = userManager;
        this.mapper = mapper;
    } 

    [HttpPost]
    public async Task<ActionResult<ApplicationUser>> AddClient(IFormFile image, [FromForm] UserAddDTO user){
        ApplicationUser newUser;
        using (var ms = new MemoryStream())
        {
            image.CopyTo(ms);
            newUser = mapper.Map<ApplicationUser>(user); 
            newUser.Image = new Image(){
                Photo = ms.ToArray(),
                Description = user.FirstName + "Profie Image"
            };
        }
        var res = await userManager.CreateAsync(newUser, user.Password!);
        if(!res.Succeeded)
            return BadRequest(res.Errors);

        res = await userManager.AddToRoleAsync(newUser, "client");

        if(!res.Succeeded)
            return BadRequest(res.Errors);
            
        return Ok(newUser);
    }
}
