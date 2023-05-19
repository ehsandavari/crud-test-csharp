using Domain.Entities;

namespace Domain.Interfaces;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    Customer? Find(string email);
}