Feature: CRUD API
I want to be able to create, read, update, and delete customers

    Scenario: Create customer
        Given I have a web client
        And I have a valid customer
        When I send a GET request to the '/public/customer/get/1' endpoint
        Then I should receive a '404' response
        And I should receive a '404' response