using MediatR;

namespace ParkingSystem.Application.Commands.PriceTables;

public abstract class PriceTableCommand : IRequest<PriceTable>
{
    public decimal PayPerUse { get; set; }
    public decimal Subscription { get; set; }
}
