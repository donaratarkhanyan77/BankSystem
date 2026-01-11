using Bank.Domain.Entities;

namespace Bank.Domain.Interface.IRepositories;

public interface ITransactionRepository
{
    Task AddAsync(Transaction transaction);
}
