﻿using Application.Common.Mediator;
using Domain.Entities;

namespace Application.CustomerHandlers.Commands.Create;

public record CreateCustomerCommand
(
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    string PhoneNumber,
    string Email,
    string BankAccountNumber
) : IBaseCommand<bool>;

public static class CreateCustomerCommandMapper
{
    public static Customer ToCustomerEntity(this CreateCustomerCommand createCustomerCommand)
    {
        return new Customer
        {
            FirstName = createCustomerCommand.FirstName,
            LastName = createCustomerCommand.LastName,
            DateOfBirth = createCustomerCommand.DateOfBirth,
            PhoneNumber = createCustomerCommand.PhoneNumber,
            Email = createCustomerCommand.Email,
            BankAccountNumber = createCustomerCommand.BankAccountNumber
        };
    }
}