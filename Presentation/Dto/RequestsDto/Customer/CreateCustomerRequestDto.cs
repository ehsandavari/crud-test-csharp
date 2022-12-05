using System.ComponentModel.DataAnnotations;
using System.Net;
using Application.Common.Exceptions;
using Application.CustomerHandlers.Commands.Create;
using IbanNet.DataAnnotations;
using PhoneNumbers;

namespace Presentation.Dto.RequestsDto.Customer;

public class CreateCustomerRequestDto
{
    public CreateCustomerRequestDto(string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber,
        string email, string bankAccountNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;
    }

    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    [Required] public DateTime DateOfBirth { get; set; }
    [Required] public PhoneNumber PhoneNumber { get; set; }
    [Required] [EmailAddress] public string Email { get; set; }
    [Required] [Iban] public string BankAccountNumber { get; set; }
}

public static class CreateCustomerRequestDtoMapper
{
    public static CreateCustomerCommand ToCreateCustomerCommand(
        this CreateCustomerRequestDto createCustomerRequestDto)
    {
        if (PhoneNumberUtil.GetInstance().IsValidNumber(createCustomerRequestDto.PhoneNumber) is not true)
        {
            throw new BaseHttpException(HttpStatusCode.BadRequest, HttpExceptionTypes.PhoneNumberIsNotValid);
        }

        return new CreateCustomerCommand
        (
            FirstName: createCustomerRequestDto.FirstName,
            LastName: createCustomerRequestDto.LastName,
            DateOfBirth: createCustomerRequestDto.DateOfBirth,
            PhoneNumber: createCustomerRequestDto.PhoneNumber.ToString()!,
            Email: createCustomerRequestDto.Email,
            BankAccountNumber: createCustomerRequestDto.BankAccountNumber
        );
    }
}