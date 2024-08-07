using ParkingSystem.Domain.Validation;

namespace ParkingSystem.Domain.Entities;

public class Membership : Entity
{
    public string Name { get; private set; }
    public string CPF { get; private set; }
    public string Phone { get; private set; }
    public string Email { get; private set; }
    public List<Vehicle> Vehicles { get; private set; }

    public Membership(string name, string cpf, string phone, string email)
    {
        ValidateDomain(name, cpf, phone, email);
    }

    public void Update(int id, string name, string cpf, string phone, string email)
    {
        ValidateId(id);
        ValidateDomain(name, cpf, phone, email);
    }

    private void ValidateDomain(string name, string cpf, string phone, string email)
    {
        ValidateName(name);
        ValidateCPF(cpf);
        ValidatePhone(phone);
        ValidateEmail(email);
    }

    private void ValidateName(string name)
    {
        int MaxNameLength = 255;
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required.");
        DomainExceptionValidation.When(name.Length > MaxNameLength, $"Subscriber name cannot exceed {MaxNameLength} characters.");
        Name = name;
    }

    private void ValidateCPF(string cpf)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(cpf), "CPF is required.");
        CPF = cpf;
    }

    private void ValidatePhone(string phone)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(phone), "Phone number is required.");
        Phone = phone;
    }

    private void ValidateEmail(string email)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(email), "Email is required.");
        DomainExceptionValidation.When(!email.Contains("@"), "Invalid email address.");
        Email = email;
    }
}
