using Application.Common.Mediator;
using Application.CustomerHandlers.Queries.GetById.VirtualModels;

namespace Application.CustomerHandlers.Queries.GetById;

public record GetCustomerByIdQuery
(
    long Id
) : IBaseQuery<GetCustomerByIdVirtualModel>;