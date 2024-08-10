using ParkingSystem.Application.Commands.PriceTables;

namespace ParkingSystem.Application.Commands.Categories;

public class CategoryUpdateCommand : CategoryCommand
{
    public int Id {  get; set; }
    public PriceTableUpdateCommand PriceTable { get; set; }
}
