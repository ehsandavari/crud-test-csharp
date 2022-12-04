using Application.Common.Mediator;
using Application.CustomerHandlers.Queries.GeByFilter.VirtualModels;
using Domain.Interfaces;

namespace Application.CustomerHandlers.Queries.GeByFilter;

public class
    GetCustomersByFilterQueryHandler : IBaseQueryHandler<GetCustomersByFilterQuery,
        Tuple<IQueryable<GetCustomersByFilterVirtualModel>, int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCustomersByFilterQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Tuple<IQueryable<GetCustomersByFilterVirtualModel>, int>> Handle(
        GetCustomersByFilterQuery request,
        CancellationToken cancellationToken)
    {
        var result = _unitOfWork.CustomerRepository.OrderByDescending(customer => customer.UpdatedAt).AsQueryable();

        return Task.FromResult(
            new Tuple<IQueryable<GetCustomersByFilterVirtualModel>, int>(
                result.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize)
                    .Select(customer => customer.ToGetCustomerByFilterVirtualModelMapper()),
                result.Count()
            )
        );
    }
}