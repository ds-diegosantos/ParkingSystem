namespace ParkingSystem.Domain.Interfaces;

public interface IPriceTableRepository
{
    Task<PriceTable> CreateAsync(PriceTable priceTable);
}