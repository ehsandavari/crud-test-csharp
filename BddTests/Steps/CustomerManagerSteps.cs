using Application.Common.Exceptions;
using BddTests.Drivers;
using TechTalk.SpecFlow.Assist;

namespace BddTests.Steps;

[Binding]
public class CustomerManagerSteps
{
    private const string BaseUrl = "http://localhost:8000";

    private readonly ScenarioContext _scenarioContext;
    private readonly WebDriver _webDriver;

    public CustomerManagerSteps(ScenarioContext scenarioContext, WebDriver webDriver)
    {
        _scenarioContext = scenarioContext;
        _webDriver = webDriver;
    }

    [Given(@"http client requester")]
    public void GivenHttpClientRequester()
    {
        _webDriver.InitializeHttpClient();
    }

    [Given(@"system error codes are following")]
    public void GivenSystemErrorCodesAreFollowing(Table table)
    {
        _scenarioContext.Set(table.CreateSet<BaseHttpException>());
    }

    [When(@"user creates a customer with following data by sending '(.*)'")]
    public void WhenUserCreatesACustomerWithFollowingDataBySending(string p0, Table table)
    {
        _webDriver.HttpClientPost(BaseUrl + "", "");
    }

    [Then(@"user can lookup all customers and filter by below properties and get '(.*)' records")]
    public void ThenUserCanLookupAllCustomersAndFilterByBelowPropertiesAndGetRecords(string p0, Table table)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"user gets error with code '(.*)'")]
    public void ThenUserGetsErrorWithCode(string p0)
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"user edit customer with new data")]
    public void WhenUserEditCustomerWithNewData(Table table)
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"user delete customer by Email of '(.*)'")]
    public void WhenUserDeleteCustomerByEmailOf(string p0)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"user can get all records and get '(.*)' records")]
    public void ThenUserCanGetAllRecordsAndGetRecords(string p0)
    {
        ScenarioContext.StepIsPending();
    }
}