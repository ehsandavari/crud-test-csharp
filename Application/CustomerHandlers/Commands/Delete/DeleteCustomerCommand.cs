using Application.Common.Mediator;

namespace Application.CustomerHandlers.Commands.Delete;

public record DeleteCustomerCommand
(
    long Id
) : IBaseCommand<bool>;
 