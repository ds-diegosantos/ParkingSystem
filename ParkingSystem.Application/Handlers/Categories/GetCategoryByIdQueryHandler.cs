using MediatR;
using ParkingSystem.Application.Queries.Categories;
using ParkingSystem.Domain.Entities;
using ParkingSystem.Domain.Interfaces;

namespace ParkingSystem.Application.Handlers.Categories;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        return await _categoryRepository.GetByIdAsync(request.Id);
    }
}
