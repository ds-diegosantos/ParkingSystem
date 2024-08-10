using MediatR;
using ParkingSystem.Domain.Entities;

namespace ParkingSystem.Application.Commands.Categories;

public class CategoryDeleteCommand : IRequest<Category>
{
    public int Id { get; set; }
}
