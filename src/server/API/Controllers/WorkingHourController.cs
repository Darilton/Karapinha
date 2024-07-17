using DTO;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Model;
using Shared;

namespace API;

[ApiController]
[Route("[controller]")]
public class WorkingHourController : ControllerBase
{
    private readonly IWorkingHourService service;

    public WorkingHourController(IWorkingHourService service){
        this.service = service;
    }

    [HttpPost]
    public async Task<ActionResult> Post(int hour, int minute, int seconds){      
        return Ok(await service.AddHour(hour, minute, seconds));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorkingHourDTO>>> Get(){
        return Ok(await service.GetHours());
    }

    [HttpDelete("id")]
    public async Task<ActionResult> Delete(int id){
        var res = await service.DeleteHour(id);

        if(res == Shared.Response.NOT_FOUND)
            return NotFound();
        
        return Ok();
    }

    [HttpGet("id")]
    public async Task<ActionResult<WorkingHourDTO>> Get(int id){
        WorkingHourDTO workingHour = await service.GetHour(id);

        if(workingHour == null)
            return NotFound();

        return Ok(workingHour);
    }

    [HttpPut("id")]
    public async Task<ActionResult> Put(int id,WorkingHourDTO workingHour){
        var res = await service.EditHour(id, workingHour);

        if(res == Shared.Response.NOT_FOUND)
            return NotFound();

        if(res == Shared.Response.BAD_REQUEST)
            return BadRequest();
        
        return Ok();
    }
}
