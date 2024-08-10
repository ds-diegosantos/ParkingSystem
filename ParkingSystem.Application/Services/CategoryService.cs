
using AutoMapper;
using MediatR;
using ParkingSystem.Application.Commands.Categories;
using ParkingSystem.Application.DTOs.Category.Requests;
using ParkingSystem.Application.DTOs.Category.response;
using ParkingSystem.Application.Interfaces;
using ParkingSystem.Application.Queries.Categories;
using ParkingSystem.Domain.Pagination;

namespace ParkingSystem.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    public CategoryService(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<CategoryDTO> CreateAsync(CreateCategoryDTO categoryDto)
    {
        var categoryCreateCommand = _mapper.Map<CategoryCreateCommand>(categoryDto);
        var category = await _mediator.Send(categoryCreateCommand);
        return _mapper.Map<CategoryDTO>(category);
    }

    public async Task<PagedResult<CategoryDTO>> get(CategoryParameters parameters)
    {
        var getCategoriesQuery = _mapper.Map<GetCategoriesQuery>(parameters);
        var categories = await _mediator.Send(getCategoriesQuery);
        return _mapper.Map<PagedResult<CategoryDTO>>(categories);
    }
}
