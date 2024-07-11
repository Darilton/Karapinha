using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace API;

[ApiController]
[Route("[controller]")]
public class CategoryController: ControllerBase
{   
    private readonly AppDbCotnext db;
    public CategoryController(AppDbCotnext db){
        this.db = db;
    }

    [HttpGet]
    public ActionResult Get(){
        return Ok(db.Categories.ToList());
    }

    [HttpGet("{categoryId}/Services")]
    public ActionResult GetServices(int categoryId){
        Category? category = db.Categories.Include(category => category.Services).FirstOrDefault(category => categoryId == category.Id);

        if(category == null)
            return NotFound("Category Not found");

        return Ok(category.Services);
    }

    [HttpPost]
    public ActionResult Post([FromBody] Category category){
        var res = db.Categories.Add(category);
        db.SaveChanges();
        return Ok(res.Entity);
    }
}
