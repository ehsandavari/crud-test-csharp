using Application.Common.Mediator;

namespace Application.CustomerHandlers.Commands.Update;

public record UpdateCustomerCommand
(
    long Id,
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    string PhoneNumber,
    string Email,
    string BankAccountNumber
) : IBaseCommand<bool>; 