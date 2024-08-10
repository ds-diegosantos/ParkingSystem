namespace ParkingSystem.Domain.Interfaces;

public interface IPriceTableRepository
{
    Task<IEnumerable<PriceTable>> GetAllAsync();
    Task<PriceTable> GetByIdAsync(int id);
    Task<PriceTable> CreateAsync(PriceTable priceTable);
    Task<PriceTable> UpdateAsync(PriceTable priceTable);
    Task<PriceTable> DeleteAsync(PriceTable priceTable);
}