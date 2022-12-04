using Domain.Entities;
using Domain.Interfaces;

namespace Persistence.Repositories;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(DataBaseContext context) : base(context)
    {
    }
}