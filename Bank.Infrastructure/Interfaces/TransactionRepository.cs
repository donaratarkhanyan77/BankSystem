using Bank.Domain.Entities;
using Bank.Domain.Interface.IRepositories;
using Bank.Infrastructure.Data;

namespace Bank.Infrastructure.Interfaces;

public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
{
    public TransactionRepository(BankDbContext context) : base(context)
    {
    }
}

