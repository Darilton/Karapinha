using Data;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API;

[ApiController]
[Route("[controller]")]
public class ServiceController: ControllerBase
{
    private readonly AppDbCotnext db;

    public ServiceController(AppDbCotnext db){
        this.db = db;
    }

}
