using System.Net;
using System.Net.Mime;
using System.Text;
using Application.Common.Exceptions;
using Domain.ValueObject;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Presentation.Dto;
using Presentation.Dto.RequestsDto.Customer;
using TechTalk.SpecFlow.Assist;

namespace BddTests.Steps;

[Binding]
public class CustomerManagerSteps
{
    private const string BaseUrl = "http://localhost:8200";

    private readonly ScenarioContext _scenarioContext;
    private readonly WebApplicationFactory<Program> _factory;

    public CustomerManagerSteps(ScenarioContext scenarioContext, WebApplicationFactory<Program> factory)
    {
        _scenarioContext = scenarioContext;
        _factory = factory;
    }

    [Given(@"system error codes are following")]
    public void GivenSystemErrorCodesAreFollowing(Table table)
    {
        _scenarioContext.Set(table.CreateSet<BaseHttpException>());
    }


    [When(@"user creates a customer with following data by sending Create Customer Command")]
    public void WhenUserCreatesACustomerWithFollowingDataBySending(Table table)
    {
        var customers = table.CreateSet<CreateCustomerRequest>();
        var client = _factory.CreateClient();
        foreach (var createCustomerRequestDto in customers)
        {
            var response = client.PostAsync(BaseUrl + "/public/customer/create",
                new StringContent(JsonConvert.SerializeObject(createCustomerRequestDto), Encoding.UTF8,
                    MediaTypeNames.Application.Json));
            response.Result.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }

    [Then(@"user can lookup all customers and filter by below properties and get '(.*)' records")]
    public void ThenUserCanLookupAllCustomersAndFilterByBelowPropertiesAndGetRecords(int count, Table table)
    {
        var customers = table.CreateSet<CustomerListWithPaginationRequestDto>();
        var client = _factory.CreateClient();
        foreach (var customerListWithPaginationRequestDto in customers)
        {
            var response = client.PostAsync(BaseUrl + "/public/customer/list-by-paginate",
                new StringContent(JsonConvert.SerializeObject(customerListWithPaginationRequestDto), Encoding.UTF8,
                    MediaTypeNames.Application.Json));
            response.Result.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseBody = JsonConvert
                .DeserializeObject<ApiResultWithData<PaginatedList<ListCustomerWithPaginationResponse>>>(
                    response.Result.Content.ReadAsStringAsync().Result);
            responseBody.Should().NotBeNull();
            responseBody!.Data.TotalCount.Should().Be(count);
        }
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

public class CreateCustomerRequest
{
    public CreateCustomerRequest(string firstName, string lastName, string dateOfBirth, string phoneNumber,
        string email, string bankAccountNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public string DateOfBirth { get; }
    public string PhoneNumber { get; }
    public string Email { get; }
    public string BankAccountNumber { get; }
}

public class ListCustomerWithPaginationResponse : BaseResponseDto
{
    public ListCustomerWithPaginationResponse(long id, string firstName, string lastName, DateTime dateOfBirth,
        PhoneNumber phoneNumber, string email, string bankAccountNumber, DateTime createdAt, DateTime updatedAt) : base(
        id, createdAt, updatedAt)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public DateTime DateOfBirth { get; }
    public PhoneNumber PhoneNumber { get; }
    public string Email { get; }
    public string BankAccountNumber { get; }
}