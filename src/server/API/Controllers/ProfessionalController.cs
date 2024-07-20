using DTO;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace API;

[ApiController]
[Route("[controller]")]
public class ProfessionalController : ControllerBase
{
    private readonly IProfessionalService service;

    public ProfessionalController(IProfessionalService service)
    {
        this.service = service;
    }
    [HttpPost]
    public async Task<ActionResult<ProfessionalDTO>> Post(IFormFile professionalImage, [FromForm]ProfessionalAddDTO professional){
        byte[] image;
        using (var ms = new MemoryStream()){
            professionalImage.CopyTo(ms);
            image = ms.ToArray();
        }

        Tuple<ProfessionalDTO, string> res = await service.AddProfessional(professional, image);

        if(res.Item1 == null)
            return BadRequest(res.Item2);

        return Ok(res.Item1);
    }
}
