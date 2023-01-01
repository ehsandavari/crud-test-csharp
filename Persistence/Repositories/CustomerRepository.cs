using Domain.Entities;
using Domain.Interfaces;

namespace Persistence.Repositories;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(DataBaseContext context) : base(context)
    {
    }

    public Customer? Find(string email)
    {
        return DataBaseContext.Customers.FirstOrDefault(customer => customer.Email.Equals(email.ToLower()));
    }
}