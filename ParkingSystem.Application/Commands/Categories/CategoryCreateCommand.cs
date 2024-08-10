using ParkingSystem.Application.Commands.PriceTables;

namespace ParkingSystem.Application.Commands.Categories;

public class CategoryCreateCommand : CategoryCommand
{
    public PriceTableCreateCommand PriceTable { get; set; }
}

