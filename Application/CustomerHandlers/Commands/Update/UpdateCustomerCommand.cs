using Application.Common.Mediator;
using Domain.ValueObject;

namespace Application.CustomerHandlers.Commands.Update;

public record UpdateCustomerCommand
(
    long Id,
    string FirstName,
    string LastName,
    DateOnly DateOfBirth,
    PhoneNumber PhoneNumber,
    string Email,
    string BankAccountNumber
) : IBaseCommand<long>; 