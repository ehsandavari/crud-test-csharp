using Application.CustomerHandlers.Commands.Delete;
using Application.CustomerHandlers.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Dto;
using Presentation.Dto.RequestsDto.Customer;
using Presentation.Dto.ResponsesDto.Customer;

namespace Presentation.Controllers.Public;

public class CustomerController : BasePublicController
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResultWithData<PaginatedList<ListCustomerWithPaginationResponseDto>>),
        StatusCodes.Status200OK)]
    public async Task<ApiResultWithData<PaginatedList<ListCustomerWithPaginationResponseDto>>> ListByPaginate(
        CustomerListWithPaginationRequestDto request)
    {
        var response = await _mediator.Send(request.ToGetCustomerListByFilterQuery());
        var paginatedList = await response.Item1.Select(item => item.ToListCustomerWithPaginationResponseDto())
            .PaginatedListAsync(response.Item2, request.PageNumber, request.PageSize);
        return ApiResultWithData(paginatedList);
    }

    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(ApiResultWithData<GetCustomerResponseDto>), StatusCodes.Status200OK)]
    public async Task<ApiResultWithData<GetCustomerResponseDto>> Get(long id)
    {
        var getCustomerByIdVirtualModel = await _mediator.Send(new GetCustomerByIdQuery(id));
        return ApiResultWithData(getCustomerByIdVirtualModel.ToGetCustomerResponseDto());
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResult), StatusCodes.Status200OK)]
    public async Task<ApiResult> Create([FromBody] CreateCustomerRequestDto request)
    {
        return ApiResult(await _mediator.Send(request.ToCreateCustomerCommand()));
    }

    [HttpPut("{id:long}")]
    [ProducesResponseType(typeof(ApiResult), StatusCodes.Status200OK)]
    public async Task<ApiResult> Update([FromBody] UpdateCustomerRequestDto request, long id)
    {
        return ApiResult(await _mediator.Send(request.ToUpdateCustomerCommand(id)));
    }

    [HttpDelete("{id:long}")]
    [ProducesResponseType(typeof(ApiResult), StatusCodes.Status200OK)]
    public async Task<ApiResult> Delete(long id)
    {
        return ApiResult(await _mediator.Send(new DeleteCustomerCommand(id)));
    }
}