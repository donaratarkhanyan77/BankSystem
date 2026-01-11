using Bank.Domain.Entities;
using Bank.Domain.Interface.IRepositories;
using Bank.Infrastructure.Data;

namespace Bank.Infrastructure.Interfaces;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(BankDbContext context) : base(context)
    {
    }
}

