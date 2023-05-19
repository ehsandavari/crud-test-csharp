using Application.Common.Mediator;

namespace Application.CustomerHandlers.Commands.Delete;

public record DeleteCustomerCommand
(
    string Email
) : IBaseCommand<long>;
 