namespace ParkingSystem.Domain.Interfaces;

public interface IPriceTableRepository
{
    Task<PriceTable> CreateAsync(PriceTable priceTable);
    Task<PriceTable> UpdateAsync(PriceTable priceTable);
    Task<PriceTable> getByIdAsync(int id);

}