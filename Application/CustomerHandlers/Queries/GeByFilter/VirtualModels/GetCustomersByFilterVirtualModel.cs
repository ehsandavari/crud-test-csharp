using Application.Common.Models;
using Domain.Entities;

namespace Application.CustomerHandlers.Queries.GeByFilter.VirtualModels;

public record GetCustomersByFilterVirtualModel
(
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    string PhoneNumber,
    string Email,
    string BankAccountNumber
) : BaseVirtualModel;

public static class GetCustomerByFilterVirtualModelMapper
{
    public static GetCustomersByFilterVirtualModel ToGetCustomerByFilterVirtualModelMapper(this Customer customer)
    {
        return new GetCustomersByFilterVirtualModel(
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