using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Shared;

namespace API;

[ApiController]
[Route("[controller]")]
public class CategoryController: ControllerBase
{   
    private readonly IGenericRepository<Category> repo;
    public CategoryController(IGenericRepository<Category> repo){
        this.repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> Get(){
        return Ok(await repo.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> Get(int id){
        Category category = await repo.GetByIdAsync(id);

        if(category == null)
            return NotFound();
        
        return Ok(category);
    }

    // [HttpGet("{categoryId}/Services")]
    // public ActionResult GetServices(int categoryId){
    //     Category? category = db.Categories.Include(category => category.Services).FirstOrDefault(category => categoryId == category.Id);

    //     if(category == null)
    //         return NotFound("Category Not found");

    //     return Ok(category.Services);
    // }

    [HttpPost]
    public async Task<ActionResult<Category>> Post([FromBody] Category category){
        if(category == null)
            return BadRequest();
        
        Category cat = await repo.InsertAsync(category);
        return Ok(cat);
    }

    // [HttpDelete]
    // public async Task<ActionResult> Delete(){
    //     await repo.DeleteAsync();
    // }
}
