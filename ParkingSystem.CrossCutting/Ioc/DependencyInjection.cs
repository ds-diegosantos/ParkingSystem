using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkingSystem.Application.Interfaces;
using ParkingSystem.Application.Mappings;
using ParkingSystem.Application.Services;
using ParkingSystem.Domain.Interfaces;
using ParkingSystem.Infrastructure.Context;
using ParkingSystem.Infrastructure.Repositories;

namespace ParkingSystem.CrossCutting.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
          options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IPriceTableRepository, PriceTableRepository>();
        services.AddScoped<ISpotRepository, SpotRepository>();


        services.AddScoped<ICategoryService, CategoryService>();


        services.AddAutoMapper(typeof(DTOToCommandMappingProfile));
        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        var myHandlers = AppDomain.CurrentDomain.Load("ParkingSystem.Application");
        services.AddMediatR(myHandlers);

        return services;
    }
}
