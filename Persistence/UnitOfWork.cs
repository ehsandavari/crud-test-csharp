using Domain.Interfaces;

namespace Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataBaseContext _context;


    public UnitOfWork(DataBaseContext context, ICustomerRepository customerRepository)
    {
        _context = context;
        CustomerRepository = customerRepository;
    }

    public ICustomerRepository CustomerRepository { get; }

    public Task<int> Complete(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    void IDisposable.Dispose() => _context.Dispose(); 
}