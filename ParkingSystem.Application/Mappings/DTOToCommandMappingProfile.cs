using AutoMapper;
using ParkingSystem.Application.Commands.Categories;
using ParkingSystem.Application.Commands.PriceTables;
using ParkingSystem.Application.DTOs.Category.Requests;
using ParkingSystem.Application.DTOs.PriceTable;
using ParkingSystem.Application.Queries.Categories;

namespace ParkingSystem.Application.Mappings;

public class DTOToCommandMappingProfile : Profile
{
    public DTOToCommandMappingProfile()
    {
        CreateMap<CreateCategoryDTO, CategoryCreateCommand>().ReverseMap();
        CreateMap<PriceTableDTO, PriceTableCreateCommand>().ReverseMap();
        CreateMap<CategoryParameters, GetCategoriesQuery>().ReverseMap();
    }
}
