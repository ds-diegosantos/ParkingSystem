using MediatR;
using ParkingSystem.Application.Commands.PriceTables;
using ParkingSystem.Domain.Interfaces;

namespace ParkingSystem.Application.Handlers.PriceTables;

public class PriceTableCreateCommandHandler : IRequestHandler<PriceTableCreateCommand, PriceTable>
{
    private readonly IPriceTableRepository _priceTableRepository;
    public PriceTableCreateCommandHandler(IPriceTableRepository priceTableRepository)
    {
        _priceTableRepository = priceTableRepository;
    }

    public async Task<PriceTable> Handle(PriceTableCreateCommand request, CancellationToken cancellationToken)
    {
        var priceTable = new PriceTable(request.PayPerUse,request.Subscription);
        return await _priceTableRepository.CreateAsync(priceTable);
    }
}
