namespace ParkingSystem.Domain.Entities;

public class SubscriberCategory : Entity
{
    public bool IsInUse { get; set; }
    public Category Category { get; set; }
    public int CategoryId { get; set; }
    public int MembershipPaymentId { get; set; }


    public SubscriberCategory()
    {
        IsInUse = false;
    }

}
