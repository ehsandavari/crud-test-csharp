using System.Net;
using Application.Common.Exceptions;
using Application.Common.Mediator;
using Domain.Interfaces;

namespace Application.CustomerHandlers.Commands.Delete;

public class DeleteCustomerCommandHandler : IBaseCommandHandler<DeleteCustomerCommand, long>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<long> Handle(DeleteCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var customerEntity = _unitOfWork.CustomerRepository.Find(request.Email);
        if (customerEntity is null)
            throw new BaseHttpException(HttpStatusCode.NotFound, HttpExceptionTypes.CustomerIsNotFound);

        _unitOfWork.CustomerRepository.Remove(customerEntity);
        await _unitOfWork.Complete(cancellationToken);
        return customerEntity.Id;
    }
}