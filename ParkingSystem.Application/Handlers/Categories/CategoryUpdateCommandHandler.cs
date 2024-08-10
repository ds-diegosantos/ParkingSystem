using MediatR;
using ParkingSystem.Application.Commands.Categories;
using ParkingSystem.Application.Commands.PriceTables;
using ParkingSystem.Application.Commands.Spots;
using ParkingSystem.Domain.Entities;
using ParkingSystem.Domain.Interfaces;

namespace ParkingSystem.Application.Handlers.Categories;

public class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommand, Category>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ISpotRepository _spotRepository;
    private readonly IMediator _mediator;

    public CategoryUpdateCommandHandler(IMediator mediator, ICategoryRepository categoryRepository, ISpotRepository spotRepository)
    {
        _categoryRepository = categoryRepository;
        _spotRepository = spotRepository;
        _mediator = mediator;
    }

    public async Task<Category> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);
        if (category == null)
            throw new KeyNotFoundException($"Category with ID {request.Id} not found.");

        var priceTableUpdateCommand = request.PriceTable;
        priceTableUpdateCommand.Id = category.Id;

        var PriceTable = await _mediator.Send(priceTableUpdateCommand, cancellationToken);

        UpdatePriceTable(category.PriceTable, request.PriceTable);
        await AdjustSpotsAsync(category, request.SpotCount, cancellationToken);
        category.Update(request.Id, request.Name);
        category.PriceTable = PriceTable;

        await _categoryRepository.UpdateAsync(category);
        return category;
    }

    private void UpdatePriceTable(PriceTable currentPriceTable, PriceTableUpdateCommand newPriceTable)
    {
        currentPriceTable.Update(newPriceTable.PayPerUse, newPriceTable.Subscription);
    }

    private async Task AdjustSpotsAsync(Category category, int desiredSpotCount, CancellationToken cancellationToken)
    {
        if (category.Spots.Count > desiredSpotCount)
        {
            await RemoveExcessSpotsAsync(category, desiredSpotCount, cancellationToken);
        }
        else if (category.Spots.Count < desiredSpotCount)
        {
            await AddSpotsAsync(category, desiredSpotCount, cancellationToken);
        }
    }

    private async Task RemoveExcessSpotsAsync(Category category, int desiredSpotCount, CancellationToken cancellationToken)
    {
        int spotsToRemove = category.Spots.Count - desiredSpotCount;

        if (category.GetAvailableSpots() < spotsToRemove)
        {
            throw new InvalidOperationException("Cannot reduce the number of spots as there are occupied spots.");
        }

        var spotsToBeRemoved = category.Spots
            .Where(spot => !spot.IsOccupied)
            .Take(spotsToRemove)
            .ToList();

        foreach (var spot in spotsToBeRemoved)
        {
            await _spotRepository.DeleteAsync(spot);
        }

        category.ReorderSpots();
    }

    private async Task AddSpotsAsync(Category category, int desiredSpotCount, CancellationToken cancellationToken)
    {
        int currentMaxNumber = category.Spots.Any() ? category.Spots.Max(spot => spot.Number) : 0;
        int spotsToAdd = desiredSpotCount - category.Spots.Count;

        for (int i = 1; i <= spotsToAdd; i++)
        {
            var spotCommand = new SpotCreateCommand
            {
                Number = currentMaxNumber + i,
                CategoryId = category.Id
            };

            await _mediator.Send(spotCommand, cancellationToken);
        }
    }
}
