using MediatR;
using ParkingSystem.Domain.Entities;

namespace ParkingSystem.Application.Commands.Spots;

public class SpotCreateCommand : IRequest<Spot>
{
    public int Number { get; set; }
    public int CategoryId { get; set; }

}
