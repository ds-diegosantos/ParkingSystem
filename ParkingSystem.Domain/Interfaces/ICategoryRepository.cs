using ParkingSystem.Domain.Entities;
using ParkingSystem.Domain.Pagination;

namespace ParkingSystem.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<Category> CreateAsync(Category category);
    Task<PagedResult<Category>> GetCategoriesAsync(int pageSize, int currentPage);
    Task<Category> GetByIdAsync(int id);
    Task<Category> DeleteAsync(Category category);
    Task<Category> UpdateAsync(Category category);

}
