using Domain.ValueObject;

namespace Domain.Entities;

public class Customer : Base
{
    private string _firstName;

    public string FirstName
    {
        get => _firstName;
        set => _firstName = value.ToLower().Trim();
    }

    private string _lastName;

    public string LastName
    {
        get => _lastName;
        set => _lastName = value.ToLower().Trim();
    }

    public DateOnly DateOfBirth { get; set; }
    public PhoneNumber PhoneNumber { get; set; }

    private string _email;

    public string Email
    {
        get => _email;
        set => _email = value.ToLower().Trim();
    }

    public string BankAccountNumber { get; set; }
}