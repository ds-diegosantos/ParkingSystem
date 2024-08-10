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
    public async Task<ActionResult<CategoryDTO>> Post(CreateCategoryDTO createCategoryDTO)
    {
        var category = await _categoryService.CreateAsync(createCategoryDTO);
        return Ok(category);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get([FromQuery] CategoryParameters parameters) 
    {
        var categories = await _categoryService.get(parameters);
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

}
