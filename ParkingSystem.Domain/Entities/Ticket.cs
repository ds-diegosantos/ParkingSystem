using ParkingSystem.Domain.Enums;

namespace ParkingSystem.Domain.Entities;

public class Ticket : Entity
{
    public TicketType Type { get; private set; }
    public Vehicle Vehicle { get; private set; }
    public DateTime EntryTime { get; private set; }
    public DateTime? ExitTime { get; private set; }
    public decimal Value { get; private set; }
    public TicketStatus Status { get; private set; }
    public Spot Spot { get; set; }
    public int SpotId { get; set; }
    public Payment Payment { get; set; }
    public int PaymentId { get; set; }
}
