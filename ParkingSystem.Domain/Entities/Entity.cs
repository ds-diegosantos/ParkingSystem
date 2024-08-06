using ParkingSystem.Domain.Validation;

namespace ParkingSystem.Domain.Entities;

public abstract class Entity
{
    public int Id { get; private set; }
    protected void ValidateId(int id)
    {
        DomainExceptionValidation.When(id < 0, "Invalid id value.");
        Id = id;
    }
}
