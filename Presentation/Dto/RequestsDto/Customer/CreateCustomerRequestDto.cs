using System.ComponentModel.DataAnnotations;
using System.Net;
using Application.Common.Exceptions;
using Application.CustomerHandlers.Commands.Create;
using IbanNet.DataAnnotations;
using PhoneNumbers;
using PhoneNumber = Domain.ValueObject.PhoneNumber;

namespace Presentation.Dto.RequestsDto.Customer;

public class CreateCustomerRequestDto
{
    public CreateCustomerRequestDto(string firstName, string lastName, DateOnly dateOfBirth, string phoneNumber,
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

public static class CreateCustomerRequestDtoMapper
{
    public static CreateCustomerCommand ToCreateCustomerCommand(
        this CreateCustomerRequestDto createCustomerRequestDto)
    {
        var phoneNumber = PhoneNumberUtil.GetInstance().Parse(createCustomerRequestDto.PhoneNumber, "");
        if (PhoneNumberUtil.GetInstance().IsValidNumber(phoneNumber) is not true)
        {
            throw new BaseHttpException(HttpStatusCode.BadRequest, HttpExceptionTypes.PhoneNumberIsNotValid);
        }

        if (new EmailAddressAttribute().IsValid(createCustomerRequestDto.Email) is not true)
        {
            throw new BaseHttpException(HttpStatusCode.BadRequest, HttpExceptionTypes.EmailAddressIsNotValid);
        }

        if (new IbanAttribute().IsValid(createCustomerRequestDto.BankAccountNumber) is not true)
        {
            throw new BaseHttpException(HttpStatusCode.BadRequest, HttpExceptionTypes.BankAccountNumberIsNotValid);
        }

        return new CreateCustomerCommand
        (
            FirstName: createCustomerRequestDto.FirstName,
            LastName: createCustomerRequestDto.LastName,
            DateOfBirth: createCustomerRequestDto.DateOfBirth,
            PhoneNumber: new PhoneNumber(phoneNumber.CountryCode, phoneNumber.NationalNumber),
            Email: createCustomerRequestDto.Email,
            BankAccountNumber: createCustomerRequestDto.BankAccountNumber
        );
    }
}