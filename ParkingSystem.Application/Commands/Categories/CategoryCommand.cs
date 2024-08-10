using MediatR;
using ParkingSystem.Domain.Entities;

namespace ParkingSystem.Application.Commands.Categories;

public abstract class CategoryCommand : IRequest<Category>
{
    public string Name { get; set; }
    public int SpotCount { get; set; }
}
