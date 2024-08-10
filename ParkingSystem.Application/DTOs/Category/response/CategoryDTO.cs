using ParkingSystem.Application.DTOs.PriceTable;
using ParkingSystem.Application.DTOs.Spot;

namespace ParkingSystem.Application.DTOs.Category.response;

public class CategoryDTO
{
    public string Name { get; set; }
    public PriceTableDTO PriceTable { get; set; }
    public List<SportDTO> Spots { get; set; }

}
