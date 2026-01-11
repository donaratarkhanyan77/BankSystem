using Bank.Domain.Entities;
using Bank.Domain.Interface.IRepositories;
using Bank.Infrastructure.Data;

namespace Bank.Infrastructure.Interfaces;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(BankDbContext context) : base(context)
    {
    }

    // Implement CreateAccount if specific behavior needed, otherwise forward to AddAsync
    public async Task<int> CreateAccount(Account account)
    {
        await AddAsync(account);
        return account.Id;
    }
}

