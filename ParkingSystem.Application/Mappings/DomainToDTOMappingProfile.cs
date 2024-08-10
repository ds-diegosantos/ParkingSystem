using AutoMapper;
using ParkingSystem.Application.DTOs.Category.response;
using ParkingSystem.Application.DTOs.PriceTable;
using ParkingSystem.Application.DTOs.Spot;
using ParkingSystem.Domain.Entities;
using ParkingSystem.Domain.Pagination;

namespace ParkingSystem.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<PriceTable, PriceTableDTO>().ReverseMap();
        CreateMap<Spot, SportDTO>().ReverseMap();
        CreateMap<PagedResult<Category>, PagedResult<CategoryDTO>>().ReverseMap();
    }
}