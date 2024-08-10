using ParkingSystem.Domain.Entities;
using ParkingSystem.Domain.Interfaces;
using ParkingSystem.Infrastructure.Context;

namespace ParkingSystem.Infrastructure.Repositories;

public class SpotRepository : ISpotRepository
{
    private readonly ApplicationDbContext _context;

    public SpotRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Spot> CreateAsync(Spot spot)
    {
        await _context.AddAsync(spot);
        await _context.SaveChangesAsync();
        return spot;
    }
}
