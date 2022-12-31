namespace Application.Common.Exceptions;

public enum HttpExceptionTypes
{
    PhoneNumberIsNotValid,
    EmailAddressIsNotValid,
    BankAccountNumberIsNotValid,
    DuplicateCustomerByFirstNameLastNameDateOfBirth,
    DuplicateCustomerByEmailAddress,
    CustomerIsNotFound
}