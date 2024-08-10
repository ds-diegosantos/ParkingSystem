using ParkingSystem.Application.DTOs.PriceTable;
using ParkingSystem.Application.DTOs.Spot;

namespace ParkingSystem.Application.DTOs.Category.response;

public class ResponseCategoryDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public PriceTableDTO PriceTable { get; set; }
    public List<SportDTO> Spots { get; set; }

}
