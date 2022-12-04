﻿using System.ComponentModel.DataAnnotations;
using Application.CustomerHandlers.Queries.GeByFilter.VirtualModels;
using Application.CustomerHandlers.Queries.GetById.VirtualModels;
using PhoneNumbers;

namespace Presentation.Dto.ResponsesDto.Customer;

public class GetCustomerResponseDto : BaseResponseDto
{
    public GetCustomerResponseDto(long id, string firstName, string lastName, DateTime dateOfBirth,
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

public static class GetCustomerResponseDtoMapper
{
    public static GetCustomerResponseDto ToGetCustomerResponseDto(
        this GetCustomerByIdVirtualModel getCustomerByIdVirtualModel)
    {
        return new GetCustomerResponseDto
        (
            id: getCustomerByIdVirtualModel.Id,
            firstName: getCustomerByIdVirtualModel.FirstName,
            lastName: getCustomerByIdVirtualModel.LastName,
            dateOfBirth: getCustomerByIdVirtualModel.DateOfBirth,
            phoneNumber: getCustomerByIdVirtualModel.PhoneNumber,
            email: getCustomerByIdVirtualModel.Email,
            bankAccountNumber: getCustomerByIdVirtualModel.BankAccountNumber,
            createdAt: getCustomerByIdVirtualModel.CreatedAt,
            updatedAt: getCustomerByIdVirtualModel.UpdatedAt
        );
    }
}