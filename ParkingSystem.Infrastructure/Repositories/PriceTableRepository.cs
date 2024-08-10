using Microsoft.EntityFrameworkCore;
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

    public async Task<PriceTable> getByIdAsync(int id)
    {
        return await _context.PriceTables.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<PriceTable> UpdateAsync(PriceTable priceTable)
    {
        _context.PriceTables.Update(priceTable);
        await _context.SaveChangesAsync();
        return priceTable;
    }
}