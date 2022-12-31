using Application.Common.Models;
using Domain.Entities;
using Domain.ValueObject;

namespace Application.CustomerHandlers.Queries.GetById.VirtualModels;

public record GetCustomerByIdVirtualModel
(
    string FirstName,
    string LastName,
    DateOnly DateOfBirth,
    PhoneNumber PhoneNumber,
    string Email,
    string BankAccountNumber
) : BaseVirtualModel;

public static class GetCustomerByIdVirtualModelMapper
{
    public static GetCustomerByIdVirtualModel ToGetCustomerByIdVirtualModel(this Customer customer)
    {
        return new GetCustomerByIdVirtualModel(
            FirstName: customer.FirstName,
            LastName: customer.LastName,
            DateOfBirth: customer.DateOfBirth,
            PhoneNumber: customer.PhoneNumber,
            Email: customer.Email,
            BankAccountNumber: customer.BankAccountNumber
        )
        {
            Id = customer.Id,
            CreatedAt = customer.CreatedAt,
            UpdatedAt = customer.UpdatedAt
        };
    }
}