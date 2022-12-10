using BddTests.Drivers;
using PhoneNumbers;
using Presentation.Dto.RequestsDto.Customer;

namespace BddTests.Steps;

[Binding]
public class CustomerSteps
{
    private const string BaseUrl = "http://localhost:8000";

    private readonly ScenarioContext _scenarioContext;
    private readonly WebDriver _webDriver;

    public CustomerSteps(ScenarioContext scenarioContext, WebDriver webDriver)
    {
        _scenarioContext = scenarioContext;
        _webDriver = webDriver;
    }

    [Given(@"I have a web client")]
    public void GivenIHaveAWebClient()
    {
        _webDriver.InitializeHttpClient();
    }

    [Given(@"I have a valid customer")]
    public void GivenIHaveAValidCustomer()
    {
        _scenarioContext.Set(new CreateCustomerRequestDto
        (
            "ehsan",
            "davari",
            new DateTime(),
            new PhoneNumber(),
            "ehsandavari@gmail.com",
            "1002212121665"
        ));
    }

    [When(@"I send a GET request to the '(.*)' endpoint")]
    public async Task WhenISendAGETRequestToTheApiCustomersEndpoint(string url)
    {
        await _webDriver.HttpClientGet(BaseUrl + url);
    }

    [Then(@"I should receive a '(.*)' response")]
    public void ThenIShouldReceiveAResponse(int statusCode)
    {
        _webDriver.CheckResponseStatusCode(statusCode);
    } 
}