﻿using Data;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Shared;

namespace API;

[ApiController]
[Route("[controller]")]
public class CategoryController: ControllerBase
{   
    private readonly ICategoryService service;
    public CategoryController(ICategoryService service){
        this.service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get(){
        return Ok(await service.GetCategories());
    }

    [HttpGet("id")]
    public async Task<ActionResult<CategoryDTO>> Get(int id){
        return await service.GetCategory(id);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDTO>> AddCategory(string categoryName){
        if(categoryName == null || categoryName.Length == 0)
            return BadRequest();

        return Ok(await service.AddCategory(categoryName));
    }

    [HttpDelete("id")]
    public async Task<ActionResult> Delete(int id){
        var res = await service.DeleteCategory(id);

        if(res == Shared.Response.NOT_FOUND)
            return NotFound();
        
        return Ok();
    }

    [HttpPut("id")]
    public async Task<ActionResult<CategoryDTO>> Put(int id, CategoryDTO category)
    {   
        if(id != category.Id)
            return BadRequest();

        var res = await service.EditCategory(id, category);

        if(res == Shared.Response.NOT_FOUND)
            return NotFound();

        return Ok();
    }
}
