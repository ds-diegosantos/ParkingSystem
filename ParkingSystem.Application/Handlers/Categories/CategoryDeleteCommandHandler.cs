using MediatR;
using ParkingSystem.Application.Commands.Categories;
using ParkingSystem.Domain.Entities;
using ParkingSystem.Domain.Interfaces;

namespace ParkingSystem.Application.Handlers.Categories;

public class CategoryDeleteCommandHandler : IRequestHandler<CategoryDeleteCommand, Category>
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryDeleteCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Category> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);

        if (category == null)
            throw new KeyNotFoundException($"Category with ID {request.Id} not found.");

        if (category.HasOccupiedSpot())
            throw new InvalidOperationException("Cannot delete the category because it has occupied spots.");
        
        await _categoryRepository.DeleteAsync(category);

        return category;
    }
}
