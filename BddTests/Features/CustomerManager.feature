Feature: Create Read Edit Delete Customer

    Background:
        Given http client requester
        Given system error codes are following
          | Code | Description                                                |
          | 1001 | Invalid Mobile Number                                      |
          | 1002 | Invalid Email address                                      |
          | 1003 | Invalid Bank Account Number                                |
          | 2001 | Duplicate customer by First-name, Last-name, Date-of-Birth |
          | 2002 | Duplicate customer by Email address                        |

    @ignore
    Scenario: Create Read Edit Delete Customer
        When user creates a customer with following data by sending 'Create Customer Command'
          | FirstName | LastName | Email        | PhoneNumber   | DateOfBirth | BankAccountNumber |
          | John      | Doe      | john@doe.com | +989121234567 | 01-JAN-2000 | IR000000000000001 |
        Then user can lookup all customers and filter by below properties and get '1' records
          | FirstName | LastName | Email        | PhoneNumber   | DateOfBirth | BankAccountNumber |
          | John      | Doe      | john@doe.com | +989121234567 | 01-JAN-2000 | IR000000000000001 |
        When user creates a customer with following data by sending 'Create Customer Command'
          | FirstName | LastName | Email           | PhoneNumber   | DateOfBirth | BankAccountNumber |
          | john      | doe      | ehsan@gmail.com | +989121234567 | 01-JAN-2000 | IR000000000000001 |
        Then user gets error with code '2001'
        When user creates a customer with following data by sending 'Create Customer Command'
          | FirstName | LastName | Email        | PhoneNumber   | DateOfBirth | BankAccountNumber |
          | john      | doe      | jane@doe.com | +989127654321 | 01-JAN-2002 | IR000000000000002 |
        Then user gets error with code '2002'
        When user edit customer with new data
          | FirstName | LastName | Email            | PhoneNumber | DateOfBirth | BankAccountNumber |
          | Jane      | William  | jane@william.com | +3161234567 | 01-FEB-2010 | IR000000000000002 |
        Then user can lookup all customers and filter by below properties and get '0' records
          | FirstName | LastName | Email        | PhoneNumber   | DateOfBirth | BankAccountNumber |
          | John      | Doe      | john@doe.com | +989121234567 | 01-JAN-2000 | IR000000000000001 |
        And user can lookup all customers and filter by below properties and get '1' records
          | FirstName | LastName | Email            | PhoneNumber | DateOfBirth | BankAccountNumber |
          | Jane      | William  | jane@william.com | +3161234567 | 01-FEB-2010 | IR000000000000002 |
        When user delete customer by Email of 'new@email.com'
        Then user can get all records and get '0' records