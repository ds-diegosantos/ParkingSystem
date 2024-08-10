using MediatR;
using ParkingSystem.Application.Queries.Categories;
using ParkingSystem.Domain.Entities;
using ParkingSystem.Domain.Interfaces;
using ParkingSystem.Domain.Pagination;

namespace ParkingSystem.Application.Handlers.Categories;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoriesQuery, PagedResult<Category>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<PagedResult<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _categoryRepository.GetCategories(request.PageSize, request.CurrentPage);
    }
}
