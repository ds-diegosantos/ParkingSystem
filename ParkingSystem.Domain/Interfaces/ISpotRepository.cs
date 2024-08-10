using ParkingSystem.Domain.Entities;

namespace ParkingSystem.Domain.Interfaces;

public interface ISpotRepository
{
    Task<Spot> CreateAsync(Spot spot);
    Task<Spot> DeleteAsync(Spot spot);
}
