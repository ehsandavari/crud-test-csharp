Feature: Create Read Edit Delete Customer

    Background:
        Given system error codes are following
          | HttpStatusCode | HttpExceptionType                               |
          | 1001           | PhoneNumberIsNotValid                           |
          | 1002           | EmailAddressIsNotValid                          |
          | 1003           | BankAccountNumberIsNotValid                     |
          | 2001           | DuplicateCustomerByFirstNameLastNameDateOfBirth |
          | 2002           | DuplicateCustomerByEmailAddress                 |

    Scenario: Create Read Edit Delete Customer
        When user creates a customer with following data by sending Create Customer Command
          | FirstName | LastName | Email        | PhoneNumber   | DateOfBirth | BankAccountNumber  |
          | John      | Doe      | john@doe.com | +989121234567 | 2000-02-01  | NL35ABNA7925653426 |
        Then user can lookup all customers and filter by below properties and get '1' records
          | PageNumber | PageSize | Email        |
          | 1          | 10       | john@doe.com |
        When user creates a customer with following data by sending Create Customer Command
          | FirstName | LastName | Email           | PhoneNumber   | DateOfBirth | BankAccountNumber  |
          | john      | doe      | ehsan@gmail.com | +989121234567 | 2000-02-01  | NL35ABNA7925653426 |
        Then user gets error with code '2001'
        When user creates a customer with following data by sending Create Customer Command
          | FirstName | LastName | Email        | PhoneNumber   | DateOfBirth | BankAccountNumber  |
          | ehsan     | davari   | john@doe.com | +989127654321 | 2002-03-01  | NL35ABNA7925653426 |
        Then user gets error with code '2002'
        When user edit customer with new data
          | FirstName | LastName | Email            | PhoneNumber   | DateOfBirth | BankAccountNumber  |
          | Jane      | William  | jane@william.com | +989127654321 | 2010-02-01  | NL35ABNA7925653426 |
        Then user can lookup all customers and filter by below properties and get '0' records
          | PageNumber | PageSize | Email        |
          | 1          | 10       | john@doe.com |
        And user can lookup all customers and filter by below properties and get '1' records
          | PageNumber | PageSize | Email            |
          | 1          | 10       | jane@william.com |
        When user delete customer by Email of 'jane@william.com'
        Then user can get all records and get '0' records