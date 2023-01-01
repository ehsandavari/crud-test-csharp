namespace Application.Common.Exceptions;

public enum HttpExceptionTypes
{
    PhoneNumberIsNotValid = 1001,
    EmailAddressIsNotValid = 1002,
    BankAccountNumberIsNotValid = 1003,
    DuplicateCustomerByFirstNameLastNameDateOfBirth = 2001,
    DuplicateCustomerByEmailAddress = 2002,
    CustomerIsNotFound = 2003
}