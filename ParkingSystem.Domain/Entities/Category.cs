using ParkingSystem.Domain.Validation;
using System.Data;

namespace ParkingSystem.Domain.Entities;

public class Category : Entity
{
    public string Name { get; private set; }
    public List<Spot> Spots { get; set; }
    public PriceTable PriceTable { get; set; }
    public int PriceTableId { get; set; }

    public Category(string name)
    {
        ValidateName(name);
        Spots = new List<Spot>();
    }

    public void Update(int ind, string name, int priceTableId)
    {
        ValidateId(ind);
        ValidateName(name);
        PriceTableId = priceTableId;
    }

    private void ValidateName(string name)
    {
        int MaxNameLength = 255;
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Category name is required.");
        DomainExceptionValidation.When(name.Length > MaxNameLength, $"Category name cannot exceed {MaxNameLength} characters.");

        Name = name;
    }
}
