using ParkingSystem.Application.Commands.Categories;
using ParkingSystem.Application.DTOs.Category.Requests;
using ParkingSystem.Application.DTOs.Category.response;
using ParkingSystem.Domain.Pagination;

namespace ParkingSystem.Application.Interfaces;

public interface ICategoryService
{
    Task<CategoryDTO> CreateAsync(CreateCategoryDTO categoryDto);
    Task<PagedResult<CategoryDTO>> get(CategoryParameters parameters);
}
