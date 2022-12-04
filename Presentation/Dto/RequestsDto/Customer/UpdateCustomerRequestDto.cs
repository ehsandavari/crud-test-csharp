using System.ComponentModel.DataAnnotations;
using System.Net;
using Application.Common.Exceptions;
using Application.CustomerHandlers.Commands.Update;
using IbanNet.DataAnnotations;
using PhoneNumbers;

namespace Presentation.Dto.RequestsDto.Customer;

public class UpdateCustomerRequestDto
{
    public UpdateCustomerRequestDto(string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber,
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
    [Required] public DateTime DateOfBirth { get; }
    [Required] public PhoneNumber PhoneNumber { get; }
    [Required] [EmailAddress] public string Email { get; }
    [Required] [Iban] public string BankAccountNumber { get; }
}

public static class UpdateCustomerRequestDtoMapper
{
    public static UpdateCustomerCommand ToUpdateCustomerCommand(
        this UpdateCustomerRequestDto updateCustomerRequestDto, long id)
    {
        if (PhoneNumberUtil.GetInstance().IsValidNumber(updateCustomerRequestDto.PhoneNumber) is not true)
        {
            throw new BaseHttpException(HttpStatusCode.BadRequest, HttpExceptionTypes.PhoneNumberIsNotValid);
        }

        return new UpdateCustomerCommand
        (
            Id: id,
            FirstName: updateCustomerRequestDto.FirstName,
            LastName: updateCustomerRequestDto.LastName,
            DateOfBirth: updateCustomerRequestDto.DateOfBirth,
            PhoneNumber: updateCustomerRequestDto.PhoneNumber.ToString()!,
            Email: updateCustomerRequestDto.Email,
            BankAccountNumber: updateCustomerRequestDto.BankAccountNumber
        );
    }
}