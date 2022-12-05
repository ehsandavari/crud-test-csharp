Feature: Customer

@create
Scenario: Add a customer
	Given I input firstName "firstName"
	And I input lastName "lastName"
	And I input dateOfBirth "dateOfBirth"
	And I input phoneNumber "phoneNumber"
	And I input email "email"
	And I input bankAccountNumber "bankAccountNumber"
	When I send create user request
	Then validate user is created