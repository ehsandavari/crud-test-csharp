using System.ComponentModel.DataAnnotations;
using Application.CustomerHandlers.Queries.GeByFilter;

namespace Presentation.Dto.RequestsDto.Customer;

public class CustomerListWithPaginationRequestDto : BasePaginatedListParameter
{
    public CustomerListWithPaginationRequestDto(string? email, int pageNumber = 1, int pageSize = 10) : base(pageNumber,
        pageSize)
    {
        Email = email;
    }

    [EmailAddress] public string? Email { get; }
}

public static class CustomerListWithPaginationRequestDtoMapper
{
    public static GetCustomersByFilterQuery ToGetCustomerListByFilterQuery(
        this CustomerListWithPaginationRequestDto customerListWithPaginationRequestDto)
    {
        return new GetCustomersByFilterQuery(
            PageId: customerListWithPaginationRequestDto.PageNumber,
            Take: customerListWithPaginationRequestDto.PageSize,
            Email: customerListWithPaginationRequestDto.Email
        );
    }
}