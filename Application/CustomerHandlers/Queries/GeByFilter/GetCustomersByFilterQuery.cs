using Application.Common.Mediator;
using Application.Common.Models;
using Application.CustomerHandlers.Queries.GeByFilter.VirtualModels;

namespace Application.CustomerHandlers.Queries.GeByFilter;

public record GetCustomersByFilterQuery
(
    int PageId,
    int Take,
    string? Email
) : BaseFilterParameter(PageId, Take), IBaseQuery<Tuple<IQueryable<GetCustomersByFilterVirtualModel>, int>>;