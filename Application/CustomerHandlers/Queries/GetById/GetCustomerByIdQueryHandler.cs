using System.Net;
using Application.Common.Exceptions;
using Application.Common.Mediator;
using Application.CustomerHandlers.Queries.GetById.VirtualModels;
using Domain.Interfaces;

namespace Application.CustomerHandlers.Queries.GetById;

public class GetCustomerByIdQueryHandler : IBaseQueryHandler<GetCustomerByIdQuery, GetCustomerByIdVirtualModel>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCustomerByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<GetCustomerByIdVirtualModel> Handle(GetCustomerByIdQuery request,
        CancellationToken cancellationToken)
    {
        var customerEntity = _unitOfWork.CustomerRepository.Find(request.Id);
        if (customerEntity is null)
            throw new BaseHttpException(HttpStatusCode.NotFound, HttpExceptionTypes.CustomerIsNotFound);
        return Task.FromResult(customerEntity.ToGetCustomerByIdVirtualModel());
    }
}