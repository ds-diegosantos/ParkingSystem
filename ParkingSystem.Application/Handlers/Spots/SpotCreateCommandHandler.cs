using MediatR;
using ParkingSystem.Application.Commands.Spots;
using ParkingSystem.Domain.Entities;
using ParkingSystem.Domain.Interfaces;

namespace ParkingSystem.Application.Handlers.Spots;

public class SpotCreateCommandHandler : IRequestHandler<SpotCreateCommand, Spot>
{
    private readonly ISpotRepository _spotRepository;
    public SpotCreateCommandHandler(ISpotRepository spotRepository)
    {
        _spotRepository = spotRepository;
    }

    public async Task<Spot> Handle(SpotCreateCommand request, CancellationToken cancellationToken)
    {
        var spot = new Spot(request.Number, request.CategoryId);
        return await _spotRepository.CreateAsync(spot);
    }
}
