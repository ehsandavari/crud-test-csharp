using Application.Common.Mediator;
using Domain.Interfaces;

namespace Application.CustomerHandlers.Commands.Create;

public class CreateCustomerCommandHandler : IBaseCommandHandler<CreateCustomerCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCustomerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        _unitOfWork.CustomerRepository.Add(request.ToCustomerEntity());
        return Task.FromResult(_unitOfWork.Complete(cancellationToken).IsCompletedSuccessfully);
    }
}