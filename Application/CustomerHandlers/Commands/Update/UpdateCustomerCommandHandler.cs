using System.Net;
using Application.Common.Exceptions;
using Application.Common.Mediator;
using Domain.Interfaces;

namespace Application.CustomerHandlers.Commands.Update;

public class UpdateCustomerCommandHandler : IBaseCommandHandler<UpdateCustomerCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customerEntity = _unitOfWork.CustomerRepository.Find(request.Id);
        if (customerEntity is null)
            throw new BaseHttpException(HttpStatusCode.NotFound, HttpExceptionTypes.CustomerIsNotFound);

        customerEntity.FirstName = request.FirstName;
        customerEntity.LastName = request.LastName;
        customerEntity.DateOfBirth = request.DateOfBirth;
        customerEntity.PhoneNumber = request.PhoneNumber;
        customerEntity.Email = request.Email;
        customerEntity.BankAccountNumber = request.BankAccountNumber;
        _unitOfWork.CustomerRepository.Update(customerEntity);

        return Task.FromResult(_unitOfWork.Complete(cancellationToken).IsCompletedSuccessfully);
    }
}