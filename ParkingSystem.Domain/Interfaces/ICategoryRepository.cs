using ParkingSystem.Domain.Entities;
using ParkingSystem.Domain.Pagination;

namespace ParkingSystem.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<Category> CreateAsync(Category category);
    public Task<PagedResult<Category>> GetCategories(int pageSize, int currentPage);
}
