using ParkingSystem.Domain.Validation;

namespace ParkingSystem.Domain.Entities
{
    public class Vehicle : Entity
    {
        public string Plate { get; private set; }
        public string Model { get; private set; }
        public string Color { get; private set; }
        public int MembershipId { get; set; }
        public int CategoryId { get; set; }

        public Vehicle(string plate, string model, string color)
        {
            ValidateDomain(plate, model, color);
        }

        public void Update(int id, string plate, string model, string color,int membershipId, int categoryId)
        {
            ValidateId(id);
            ValidateDomain(plate, model, color);
            MembershipId = membershipId;
            CategoryId = categoryId;
        }

        private void ValidateDomain(string plate, string model, string color)
        {
            ValidatePlate(plate);
            ValidateModel(model);
            ValidateColor(color);
        }

        private void ValidatePlate(string plate)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(plate), "Vehicle plate is required.");
            DomainExceptionValidation.When(plate.Length > 10, "Vehicle plate must be 10 characters or less.");
            Plate = plate;
        }

        private void ValidateModel(string model)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(model), "Vehicle model is required.");
            DomainExceptionValidation.When(model.Length > 50, "Vehicle model must be 50 characters or less.");
            Model = model;
        }

        private void ValidateColor(string color)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(color), "Vehicle color is required.");
            DomainExceptionValidation.When(color.Length > 30, "Vehicle color must be 30 characters or less.");
            Color = color;
        }
    }
}
