using ParkingSystem.Domain.Enums;

namespace ParkingSystem.Domain.Entities;

public class Payment : Entity
{
    public PaymentStatus Status { get; private set; }
    public decimal Amount { get; private set; }
    
    public Payment()
    {
        Status = PaymentStatus.WaitingForPayment;
    }
}
