using System.Net;
using Application.Common.Exceptions;
using Application.Common.Mediator;
using Domain.Interfaces;

namespace Application.CustomerHandlers.Commands.Update;

public class UpdateCustomerCommandHandler : IBaseCommandHandler<UpdateCustomerCommand, long>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<long> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customerEntity = _unitOfWork.CustomerRepository.Find(request.Id);
        if (customerEntity is null)
            throw new BaseHttpException(HttpStatusCode.NotFound, HttpExceptionTypes.CustomerIsNotFound);

        if (_unitOfWork.CustomerRepository.IsExists(
                expression =>
                    !expression.Id.Equals(request.Id) && expression.FirstName.Equals(request.FirstName.ToLower()) &&
                    expression.LastName.Equals(request.LastName.ToLower()) &&
                    expression.DateOfBirth.Equals(request.DateOfBirth)
            ))
            throw new BaseHttpException(HttpStatusCode.BadRequest,
                HttpExceptionTypes.DuplicateCustomerByFirstNameLastNameDateOfBirth);

        if (_unitOfWork.CustomerRepository.IsExists(expression =>
                !expression.Id.Equals(request.Id) && expression.Email.Equals(request.Email.ToLower())))
            throw new BaseHttpException(HttpStatusCode.BadRequest, HttpExceptionTypes.DuplicateCustomerByEmailAddress);

        customerEntity.FirstName = request.FirstName;
        customerEntity.LastName = request.LastName;
        customerEntity.DateOfBirth = request.DateOfBirth;
        customerEntity.PhoneNumber = request.PhoneNumber;
        customerEntity.Email = request.Email;
        customerEntity.BankAccountNumber = request.BankAccountNumber;
        _unitOfWork.CustomerRepository.Update(customerEntity);

        await _unitOfWork.Complete(cancellationToken);
        return customerEntity.Id;
    }
}