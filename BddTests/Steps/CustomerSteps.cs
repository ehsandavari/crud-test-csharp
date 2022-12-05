using PhoneNumbers;
using Presentation.Dto.RequestsDto.Customer;

namespace BddTests.Steps;

[Binding]
public class CustomerSteps
{
    private const string BaseUrl = "http://0.0.0.0:80";

    private readonly CreateCustomerRequestDto _createCustomerRequestDto;

    public CustomerSteps(CreateCustomerRequestDto createCustomerRequestDto)
    {
        _createCustomerRequestDto = createCustomerRequestDto;
    }


    [Given(@"I input firstName ""(.*)""")]
    public void GivenIInputFirstName(string firstName)
    {
        _createCustomerRequestDto.FirstName = firstName;
    }

    [Given(@"I input lastName ""(.*)""")]
    public void GivenIInputLastName(string lastName)
    {
        _createCustomerRequestDto.LastName = lastName;
    }

    [Given(@"I input dateOfBirth ""(.*)""")]
    public void GivenIInputDateOfBirth(DateTime dateOfBirth)
    {
        _createCustomerRequestDto.DateOfBirth = dateOfBirth;
    }

    [Given(@"I input phoneNumber ""(.*)""")]
    public void GivenIInputPhoneNumber(PhoneNumber phoneNumber)
    {
        _createCustomerRequestDto.PhoneNumber = phoneNumber;
    }

    [Given(@"I input email ""(.*)""")]
    public void GivenIInputEmail(string email)
    {
        _createCustomerRequestDto.Email = email;
    }

    [Given(@"I input bankAccountNumber ""(.*)""")]
    public void GivenIInputBankAccountNumber(string bankAccountNumber)
    {
        _createCustomerRequestDto.BankAccountNumber = bankAccountNumber;
    }

    [When(@"I send create user request")]
    public void WhenISendCreateUserRequest()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"validate user is created")]
    public void ThenValidateUserIsCreated()
    {
        ScenarioContext.StepIsPending();
    }
}