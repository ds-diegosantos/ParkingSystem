using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ParkingSystem.Application.Commands.Categories;
using ParkingSystem.Application.DTOs.Category.Requests;
using ParkingSystem.Application.DTOs.Category.response;
using ParkingSystem.Application.Interfaces;

namespace ParkingSystem.API.Controllers;

[Route("api/v{version:apiVersion}/[Controller]")]
[ApiController]
[ApiVersion("1.0")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    public async Task<ActionResult<ResponseCategoryDTO>> Post(RequestCategoryDTO requestCategoryDTO)
    {
        var category = await _categoryService.CreateAsync(requestCategoryDTO);
        return CreatedAtRoute("GetCategory", new { id = category.Id }, category);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ResponseCategoryDTO>> Put(int id, RequestCategoryDTO requestCategoryDTO)
    {
        var category = await _categoryService.UpdateAsync(id, requestCategoryDTO);
        return Ok(category);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ResponseCategoryDTO>>> Get([FromQuery] CategoryParameters parameters) 
    {
        var categories = await _categoryService.getAsync(parameters);
        var metadata = new
        {
            categories.TotalPages,
            categories.PageSize,
            categories.CurrentPage,
            categories.TotalCount,
            categories.HasNextPage,
            categories.HasPreviousPage
        };

        Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));

        return Ok(categories.Items);
    }

    [HttpGet("{id:int}", Name = "GetCategory")]
    public async Task<ActionResult<ResponseCategoryDTO>> Get(int id)
    {
        var category =  await _categoryService.getByIdAsync(id);

        if (category == null) return NotFound();
        return Ok(category);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ResponseCategoryDTO>> Delete(int id)
    {
        try
        {
            var deletedCategory = await _categoryService.DeleteAsync(id);
            return Ok(deletedCategory);
        }
        catch (Exception ex) when (ex is KeyNotFoundException || ex is InvalidOperationException)
        {
            return ex is KeyNotFoundException ? NotFound(ex.Message) : BadRequest(ex.Message);
        }
    }
}
