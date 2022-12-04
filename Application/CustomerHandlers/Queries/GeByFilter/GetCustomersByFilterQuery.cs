using Application.Common.Mediator;
using Application.Common.Models;
using Application.CustomerHandlers.Queries.GeByFilter.VirtualModels;

namespace Application.CustomerHandlers.Queries.GeByFilter;

public record GetCustomersByFilterQuery
(
    int PageId,
    int Take
) : BaseFilterParameter(PageId, Take), IBaseQuery<Tuple<IQueryable<GetCustomersByFilterVirtualModel>, int>>;