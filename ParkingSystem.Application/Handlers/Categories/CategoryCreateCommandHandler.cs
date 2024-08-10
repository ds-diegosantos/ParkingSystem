using MediatR;
using ParkingSystem.Application.Commands.Categories;
using ParkingSystem.Application.Commands.Spots;
using ParkingSystem.Domain.Entities;
using ParkingSystem.Domain.Interfaces;

namespace ParkingSystem.Application.Handlers.Categories;

public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommand, Category>
{
    private readonly IMediator _mediator;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryCreateCommandHandler(IMediator mediator, ICategoryRepository categoryRepository)
    {
        _mediator = mediator;
        _categoryRepository = categoryRepository;
    }


    public async Task<Category> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
    {
        var priceTable = await _mediator.Send(request.PriceTable, cancellationToken);
        var category = new Category(request.Name, priceTable.Id);

        category = await _categoryRepository.CreateAsync(category);

        for (int i = 0; i < request.SpotCount; i++)
        {
            var spotCommand = new SpotCreateCommand
            {
                Number = i,
                CategoryId = category.Id
            };

            await _mediator.Send(spotCommand, cancellationToken);
        }

        return category;
    }
}
