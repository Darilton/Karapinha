using Data;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Model;
using Shared;

namespace API;

[ApiController]
[Route("[controller]")]
public class ServiceController: ControllerBase
{
    private readonly IServiceService _service;

    public ServiceController(IServiceService service){
        this._service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServiceDTO>>> Get(){
        return Ok(await _service.GetServices());
    }

    [HttpGet("id")]
    public async Task<ActionResult<ServiceDTO>> Get(int id){
        ServiceDTO service = await _service.GetService(id);

        if(service == null)
            return NotFound();
        
        return Ok(service);
    }

    [HttpDelete("id")]
    public async Task<ActionResult> Delete(int id){
        var res = await _service.DeleteService(id);

        if(res == Shared.Response.NOT_FOUND)
            return NotFound();
        
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<ServiceDTO>> Post([FromBody]ServiceAddDTO serviceAddDTO){
        ServiceDTO newService = await _service.AddService(serviceAddDTO);
        
        if(newService == null)
            return BadRequest();
        
        return Ok(newService);  
    }

    [HttpPut("id")]
    public async Task<ActionResult> Put(int id, [FromBody]ServiceDTO serviceDTO){
        var res = await _service.EditService(id, serviceDTO);

        if(res == Shared.Response.BAD_REQUEST)
            return BadRequest();
        
        return Ok();
    }

}
