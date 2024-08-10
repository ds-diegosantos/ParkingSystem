using System.ComponentModel.DataAnnotations;

namespace ParkingSystem.Application.DTOs.PriceTable;

public class PriceTableDTO
{
    [Required(ErrorMessage = "PayPerUse is required.")]
    [Range(0, double.MaxValue, ErrorMessage = "PayPerUse must be a non-negative value.")]
    public decimal PayPerUse { get; set; }

    [Required(ErrorMessage = "Subscription is required.")]
    [Range(0, double.MaxValue, ErrorMessage = "Subscription must be a non-negative value.")]
    public decimal Subscription { get; set; }
}