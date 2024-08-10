using ParkingSystem.Application.DTOs.PriceTable;
using System.ComponentModel.DataAnnotations;

namespace ParkingSystem.Application.DTOs.Category.Requests;
public class RequestCategoryDTO
{
    [Required(ErrorMessage = "The category name is required.")]
    [StringLength(255, ErrorMessage = "The category name cannot exceed 255 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The price table is required.")]
    public PriceTableDTO PriceTable { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "The number of spots must be a non-negative integer.")]
    public int SpotCount { get; set; }
}
