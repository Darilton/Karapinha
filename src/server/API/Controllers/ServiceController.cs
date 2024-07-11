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

    [HttpGet]
    public ActionResult Get(){
        return Ok(db.Services.ToList());
    }

    [HttpPost]
    public ActionResult Post([FromBody] ServiceAddDTO serviceAddDTO){
        Category? category = db.Categories.Find(serviceAddDTO.CategoryId);
        if(category==null)
            return BadRequest("Category not found");

        Service serviceToAdd = new Service{
            Name = serviceAddDTO.Name,
            Description = serviceAddDTO.Description,
            CategoryId = category.Id,
            Category = category
        };

        var res = db.Services.Add(serviceToAdd);
        db.SaveChanges();
        return Ok(res.Entity);
    }
}
