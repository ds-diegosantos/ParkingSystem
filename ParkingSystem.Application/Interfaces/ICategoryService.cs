using ParkingSystem.Application.Commands.Categories;
using ParkingSystem.Application.DTOs.Category.Requests;
using ParkingSystem.Application.DTOs.Category.response;
using ParkingSystem.Domain.Pagination;

namespace ParkingSystem.Application.Interfaces;

public interface ICategoryService
{
    Task<ResponseCategoryDTO> CreateAsync(RequestCategoryDTO categoryDto);
    Task<PagedResult<ResponseCategoryDTO>> getAsync(CategoryParameters parameters);
    Task<ResponseCategoryDTO> getByIdAsync(int id);
    Task<ResponseCategoryDTO> DeleteAsync(int id);
    Task<ResponseCategoryDTO> UpdateAsync(int id, RequestCategoryDTO categoryDto);

}
