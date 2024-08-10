using MediatR;

namespace ParkingSystem.Application.Commands.PriceTables;

public class PriceTableCreateCommand: PriceTableCommand
{
    public decimal PayPerUse { get; set; }
    public decimal Subscription { get; set; }

}
