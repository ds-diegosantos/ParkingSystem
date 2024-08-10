using ParkingSystem.Domain.Validation;

namespace ParkingSystem.Domain.Entities;

public class Category : Entity
{
    public string Name { get; private set; }
    public List<Spot> Spots { get; set; }
    public PriceTable PriceTable { get; set; }
    public int PriceTableId { get; set; }

    public Category(string name, int priceTableId)
    {
        ValidateName(name);
        Spots = new List<Spot>();
        PriceTableId = priceTableId;
    }

    public void Update(int id, string name, int priceTableId)
    {
        ValidateId(id);
        ValidateName(name);
        PriceTableId = priceTableId;
    }

    private void ValidateName(string name)
    {
        int MaxNameLength = 255;
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required.");
        DomainExceptionValidation.When(name.Length > MaxNameLength, $"Name cannot exceed {MaxNameLength} characters.");

        Name = name;
    }
}
