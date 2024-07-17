using DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace API;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    public static Byte[]? image;
    private readonly UserManager<ApplicationUser> _userManager;
    public AuthController(UserManager<ApplicationUser> userManager){
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<ActionResult> Get(){
        var users = await _userManager.Users.ToListAsync();
        return Ok(users);
    }

    [HttpPost("uploadImage")]
    public ActionResult uploadImage(IFormFile file){
        using (var ms = new MemoryStream()){
            file.CopyTo(ms);
            image = ms.ToArray();
        }
        return Ok(File(image, "image/png", "image.png"));
    }

    [HttpGet("image")]
    public ActionResult Image(){
        return File(image, "image/png", "image.png");
    }

    [HttpPost]
    public async Task<ActionResult> RegisterUser(UserAddDto client){
        Client newClient = new Client(){
            UserName = client.UserName,
            FirstName = client.FirstName,
            LastName = client.LastName,
            Email = client.Email,
            Bilhete = client.Bilhete,
            Image = new Image(){
                Description = "imagem",
                Photo = new byte[5]
            }
        };
        var result = await _userManager.CreateAsync(newClient, client.password!);
        if(!result.Succeeded)
            return BadRequest(result.Errors);
        
        return Ok(client);
    }
}
