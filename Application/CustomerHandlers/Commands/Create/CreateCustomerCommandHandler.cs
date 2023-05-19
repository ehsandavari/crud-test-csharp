using System.Net;
using Application.Common.Exceptions;
using Application.Common.Mediator;
using Domain.Interfaces;

namespace Application.CustomerHandlers.Commands.Create;

public class CreateCustomerCommandHandler : IBaseCommandHandler<CreateCustomerCommand, long>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCustomerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<long> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        if (_unitOfWork.CustomerRepository.IsExists(
                expression =>
                    expression.FirstName.Equals(request.FirstName.ToLower()) &&
                    expression.LastName.Equals(request.LastName.ToLower()) &&
                    expression.DateOfBirth.Equals(request.DateOfBirth)
            ))
            throw new BaseHttpException(HttpStatusCode.BadRequest,
                HttpExceptionTypes.DuplicateCustomerByFirstNameLastNameDateOfBirth);

        if (_unitOfWork.CustomerRepository.IsExists(expression => expression.Email.Equals(request.Email.ToLower())))
            throw new BaseHttpException(HttpStatusCode.BadRequest, HttpExceptionTypes.DuplicateCustomerByEmailAddress);

        var entity = request.ToCustomerEntity();
        _unitOfWork.CustomerRepository.Add(entity);
        await _unitOfWork.Complete(cancellationToken);
        return entity.Id;
    }
}