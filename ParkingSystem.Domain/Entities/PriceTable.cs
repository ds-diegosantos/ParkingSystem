using ParkingSystem.Domain.Entities;
using ParkingSystem.Domain.Validation;

public class PriceTable : Entity
{
    public decimal PayPerUse { get; private set; }
    public decimal Subscription { get; private set; }

    public PriceTable(decimal payPerUse, decimal subscription)
    {
        ValidateDomain(payPerUse,subscription);
    }

    public void Update(int id, decimal payPerUse, decimal subscription)
    {
        ValidateId(id);
        ValidateDomain(payPerUse, subscription);
    }

    private void ValidateDomain(decimal payPerUse, decimal subscription)
    {
        ValidatePayPerUse(payPerUse);
        ValidateSubscription(subscription);
    }

    private void ValidatePayPerUse(decimal payPerUse)
    {
        DomainExceptionValidation.When(payPerUse < 0, "Invalid PayPerUse value. It cannot be negative.");
        PayPerUse = payPerUse;
    }

    private void ValidateSubscription(decimal subscription)
    {
        DomainExceptionValidation.When(subscription < 0, "Invalid Subscription value. It cannot be negative.");
        Subscription = subscription;
    }
}
