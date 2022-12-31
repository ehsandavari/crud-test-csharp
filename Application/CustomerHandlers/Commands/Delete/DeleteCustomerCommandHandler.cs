using System.Net;
using Application.Common.Exceptions;
using Application.Common.Mediator;
using Domain.Interfaces;

namespace Application.CustomerHandlers.Commands.Delete;

public class DeleteCustomer : IBaseCommandHandler<DeleteCustomerCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCustomer(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<bool> Handle(DeleteCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var customerEntity = _unitOfWork.CustomerRepository.Find(request.Id);
        if (customerEntity is null)
            throw new BaseHttpException(HttpStatusCode.NotFound, HttpExceptionTypes.CustomerIsNotFound);

        _unitOfWork.CustomerRepository.Remove(customerEntity);
        return Task.FromResult(_unitOfWork.Complete(cancellationToken).IsCompletedSuccessfully);
    }
}