using ParkingSystem.Domain.Enums;

namespace ParkingSystem.Domain.Entities;

public class MembershipPayment: Entity
{
    public DateTime DueDate { get; private set; }
    public List<SubscriberCategory> subscriberCategories { get; set; }
    public Membership Membership { get; set; }
    public int MembershipId { get; set; }
    public Payment Payment { get; set; }
    public int PaymentId { get; set; }

    public MembershipPayment()
    {
        DueDate = DueDate = DateTime.Now.AddMonths(1);
    }
}
