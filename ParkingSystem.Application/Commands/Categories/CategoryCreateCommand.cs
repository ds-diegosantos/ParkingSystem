using MediatR;
using ParkingSystem.Application.Commands.PriceTables;
using ParkingSystem.Domain.Entities;

namespace ParkingSystem.Application.Commands.Categories;

public class CategoryCreateCommand : IRequest<Category>
{
    public string Name { get; set; }
    public PriceTableCreateCommand PriceTable { get; set; }
    public int SpotCount { get; set; }

}

