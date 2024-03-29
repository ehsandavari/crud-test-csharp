﻿using System.ComponentModel.DataAnnotations;
using System.Net;
using Application.Common.Exceptions;
using Application.CustomerHandlers.Commands.Update;
using IbanNet.DataAnnotations;
using PhoneNumbers;
using PhoneNumber = Domain.ValueObject.PhoneNumber;

namespace Presentation.Dto.RequestsDto.Customer;

public class UpdateCustomerRequestDto
{
    public UpdateCustomerRequestDto(string firstName, string lastName, DateOnly dateOfBirth, string phoneNumber,
        string email, string bankAccountNumber)
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
    [Required] public DateOnly DateOfBirth { get; }
    [Required] public string PhoneNumber { get; }
    [Required] public string Email { get; }
    [Required] public string BankAccountNumber { get; }
}

public static class UpdateCustomerRequestDtoMapper
{
    public static UpdateCustomerCommand ToUpdateCustomerCommand(
        this UpdateCustomerRequestDto updateCustomerRequestDto, long id)
    {
        if (new PhoneAttribute().IsValid(updateCustomerRequestDto.PhoneNumber) is not true)
            throw new BaseHttpException(HttpStatusCode.BadRequest, HttpExceptionTypes.PhoneNumberIsNotValid);

        var phoneNumber = PhoneNumberUtil.GetInstance().Parse(updateCustomerRequestDto.PhoneNumber, "");
        if (PhoneNumberUtil.GetInstance().IsValidNumber(phoneNumber) is not true)
            throw new BaseHttpException(HttpStatusCode.BadRequest, HttpExceptionTypes.PhoneNumberIsNotValid);

        if (new EmailAddressAttribute().IsValid(updateCustomerRequestDto.Email) is not true)
            throw new BaseHttpException(HttpStatusCode.BadRequest, HttpExceptionTypes.EmailAddressIsNotValid);

        if (new IbanAttribute().IsValid(updateCustomerRequestDto.BankAccountNumber) is not true)
            throw new BaseHttpException(HttpStatusCode.BadRequest, HttpExceptionTypes.BankAccountNumberIsNotValid);

        return new UpdateCustomerCommand
        (
            Id: id,
            FirstName: updateCustomerRequestDto.FirstName,
            LastName: updateCustomerRequestDto.LastName,
            DateOfBirth: updateCustomerRequestDto.DateOfBirth,
            PhoneNumber: new PhoneNumber(phoneNumber.CountryCode, phoneNumber.NationalNumber),
            Email: updateCustomerRequestDto.Email,
            BankAccountNumber: updateCustomerRequestDto.BankAccountNumber
        );
    }
}