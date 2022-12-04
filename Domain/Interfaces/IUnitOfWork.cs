namespace Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{ 
    ICustomerRepository CustomerRepository { get; } 
    Task<int> Complete(CancellationToken cancellationToken);
}