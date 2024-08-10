using MediatR;
using ParkingSystem.Domain.Entities;
using ParkingSystem.Domain.Pagination;

namespace ParkingSystem.Application.Queries.Categories;

public class GetCategoriesQuery : IRequest<PagedResult<Category>>
{
    public int CurrentPage { get; set; }

    public int PageSize { get; set; }
}
