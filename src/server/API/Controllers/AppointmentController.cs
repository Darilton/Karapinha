using DTO;
using Microsoft.AspNetCore.Mvc;
using Model;
using Shared;

namespace API;

[ApiController]
[Route("[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService marcacaoService;
    private readonly IServiceProfessionalAppointmentService sapService;
    private readonly IClientService clientService;

    public AppointmentController(IServiceProfessionalAppointmentService sapService, IClientService clientService, IAppointmentService marcacaoService){
        this.marcacaoService = marcacaoService;
        this.clientService = clientService; 
        this.sapService = sapService;
    }
    [HttpGet]
    public ActionResult Get(){
        return Ok(marcacaoService.GetAppointments());
    }

    [HttpPost]
    public async Task<ActionResult<AppointmentDTO>> Post(AppointmentAddDTO appointment){
        if(await clientService.GetClientByIdAsync(appointment.ClientId) == null)
         return BadRequest("Client not found");

        if(appointment.ProfessionalAppointmentDTOs == null || appointment.ProfessionalAppointmentDTOs.Count() == 0)
            return BadRequest("List of services requested must not be empty");
        
        var res = await sapService.CreateProfessionalAppointmentAsync(appointment.ProfessionalAppointmentDTOs);
        
        if(res.Item1 == null) return BadRequest(res.Item2);

        AppointmentDTO ap = await marcacaoService.AddAppointment(appointment, res.Item1);
        if(ap == null) return BadRequest("Could not add Appointment");

        await sapService.AddList(res.Item1, ap.Id);
        return Ok();
    }
}
