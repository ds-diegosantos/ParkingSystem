using ParkingSystem.Domain.Interfaces;
using ParkingSystem.Infrastructure.Context;
namespace ParkingSystem.Infrastructure.Repositories;

public class PriceTableRepository : IPriceTableRepository
{
    private readonly ApplicationDbContext _context;

    public PriceTableRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PriceTable> CreateAsync(PriceTable priceTable)
    {
        await _context.AddAsync(priceTable);
        await _context.SaveChangesAsync();
        return priceTable;
    }

}