using MediatR;
using ParkingSystem.Domain.Entities;

namespace ParkingSystem.Application.Queries.Categories;

public class GetCategoryByIdQuery : IRequest<Category>
{
    public int Id { get; set; }
}
