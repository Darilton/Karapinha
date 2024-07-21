using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using Shared;

namespace API;

[ApiController]
[Route("[controller]")]
public class ProfessionalController : ControllerBase
{
    private readonly IProfessionalService service;
    private readonly IFileService fileService;
    private readonly IUserService userService;
    private readonly IMapper mapper;


    public ProfessionalController(IMapper mapper, IUserService userService, IFileService fileService,IProfessionalService service)
    {
        this.service = service;
        this.fileService = fileService;
        this.userService = userService;
        this.mapper = mapper;
    }


    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<ProfessionalDTO>> AddProfessional([FromForm] ProfessionalAddDTO professional, IFormFile image){
        ApplicationUser user = mapper.Map<ApplicationUser>(professional);

        user.Image = new Image(){
            Description = user.FirstName + "'s profile picture",
            Photo = fileService.ToByteArray(image)
        };

        var res = await userService.AddUserAsync(user, "professional", professional.Password!);
        if(!res.Succeeded){
            return BadRequest(res.Errors);
        } 

        ProfessionalAddDTO newProfessional = mapper.Map<ProfessionalAddDTO>(professional);
        ProfessionalDTO newUser = await service.AddProfessionalAsync(newProfessional, user);
        return Ok(newUser);
    }

    [HttpGet]
    public async Task<ActionResult<ProfessionalDTO>> Get(){
        return Ok(await service.GetProfessionalsAsync());
    }

    [HttpGet("id")]
    public async Task<ActionResult<ProfessionalDTO>> Get(int id){
        ProfessionalDTO professional = await service.GetProfessionalByIdAsync(id);

        if(professional == null) return BadRequest("User Not Foutn");

        return Ok(professional);
    }
}