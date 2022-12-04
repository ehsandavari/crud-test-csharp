using System.ComponentModel.DataAnnotations;
using Application.CustomerHandlers.Queries.GeByFilter.VirtualModels;

namespace Presentation.Dto.ResponsesDto.Customer;

public class ListCustomerWithPaginationResponseDto : BaseResponseDto
{
    public ListCustomerWithPaginationResponseDto(long id, string firstName, string lastName, DateTime dateOfBirth,
        string phoneNumber, string email, string bankAccountNumber, DateTime createdAt, DateTime updatedAt) : base(
        id, createdAt, updatedAt)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;
    }

    [Required] public string FirstName { get; }
    [Required] public string LastName { get; }
    [Required] public DateTime DateOfBirth { get; }
    [Required] public string PhoneNumber { get; }
    [Required] public string Email { get; }
    [Required] public string BankAccountNumber { get; }
}

public static class ListCustomerWithPaginationResponseDtoMapper
{
    public static ListCustomerWithPaginationResponseDto ToListCustomerWithPaginationResponseDto(
        this GetCustomersByFilterVirtualModel getCustomersByFilterVirtualModel)
    {
        return new ListCustomerWithPaginationResponseDto
        (
            id: getCustomersByFilterVirtualModel.Id,
            firstName: getCustomersByFilterVirtualModel.FirstName,
            lastName: getCustomersByFilterVirtualModel.LastName,
            dateOfBirth: getCustomersByFilterVirtualModel.DateOfBirth,
            phoneNumber: getCustomersByFilterVirtualModel.PhoneNumber,
            email: getCustomersByFilterVirtualModel.Email,
            bankAccountNumber: getCustomersByFilterVirtualModel.BankAccountNumber,
            createdAt: getCustomersByFilterVirtualModel.CreatedAt,
            updatedAt: getCustomersByFilterVirtualModel.UpdatedAt
        );
    }
}