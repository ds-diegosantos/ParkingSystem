
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

    public async Task<ResponseCategoryDTO> CreateAsync(RequestCategoryDTO categoryDto)
    {
        var categoryCreateCommand = _mapper.Map<CategoryCreateCommand>(categoryDto);
        var category = await _mediator.Send(categoryCreateCommand);
        return _mapper.Map<ResponseCategoryDTO>(category);
    }

    public async Task<ResponseCategoryDTO> DeleteAsync(int id)
    {
        var categoryDeleteCommand = new CategoryDeleteCommand() { Id = id };
        var category = await _mediator.Send(categoryDeleteCommand);
        return _mapper.Map<ResponseCategoryDTO>(category);
    }

    public async Task<PagedResult<ResponseCategoryDTO>> getAsync(CategoryParameters parameters)
    {
        var getCategoriesQuery = _mapper.Map<GetCategoriesQuery>(parameters);
        var categories = await _mediator.Send(getCategoriesQuery);
        return _mapper.Map<PagedResult<ResponseCategoryDTO>>(categories);
    }

    public async Task<ResponseCategoryDTO> getByIdAsync(int id)
    {
        var getCategoryByIdQuery = new GetCategoryByIdQuery() { Id = id };
        var category = await _mediator.Send(getCategoryByIdQuery);
        return _mapper.Map<ResponseCategoryDTO>(category);
    }

    public async Task<ResponseCategoryDTO> UpdateAsync(int id, RequestCategoryDTO categoryDto)
    {
        var categoryUpdateCommand = _mapper.Map<CategoryUpdateCommand>(categoryDto);
        categoryUpdateCommand.Id = id;
        var category = await _mediator.Send(categoryUpdateCommand);
        return _mapper.Map<ResponseCategoryDTO>(category);

    }
}
