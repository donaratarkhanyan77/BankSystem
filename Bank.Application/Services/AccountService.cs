using Bank.Application.Interfaces;
using Bank.Application.DTOs.ResponseDTOs;
using Bank.Domain.Entities;
using Bank.Domain.Interface.IRepositories;

namespace Bank.Application.Services;
public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepo;
    private readonly ITransactionRepository _transactionRepo;

    public AccountService(IAccountRepository acc, ITransactionRepository tr)
    {
        _accountRepo = acc;
        _transactionRepo = tr;
    }

    public async Task<AccountDto> DepositAsync(int accountId, decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Amount must be greater than zero.", nameof(amount));

        var account = await _accountRepo.GetByIdAsync(accountId);
        if (account == null) throw new InvalidOperationException($"Account with id {accountId} not found.");

        account.Balance += amount;

        await _accountRepo.UpdateAsync(account);

        await _transactionRepo.AddAsync(new Transaction
        {
            AccountId = account.Id,
            Amount = amount,
            Type = "Deposit"       
        });

        return new AccountDto { Id = account.Id, AccountNumber = account.AccountNumber, Balance = account.Balance };
    }

    public async Task<AccountDto> WithdrawAsync(int accountId, decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Amount must be greater than zero.", nameof(amount));

        var account = await _accountRepo.GetByIdAsync(accountId);
        if (account == null) throw new InvalidOperationException($"Account with id {accountId} not found.");
        if (account.Balance < amount) throw new InvalidOperationException("Insufficient funds.");

        account.Balance -= amount;

        await _accountRepo.UpdateAsync(account);

        await _transactionRepo.AddAsync(new Transaction
        {
            AccountId = account.Id,
            Amount = amount,
            Type = "Withdraw"
        });

        return new AccountDto { Id = account.Id, AccountNumber = account.AccountNumber, Balance = account.Balance };
    }

    public async Task TransferAsync(int fromId, int toId, decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Amount must be greater than zero.", nameof(amount));

        var fromAcc = await _accountRepo.GetByIdAsync(fromId);
        var toAcc = await _accountRepo.GetByIdAsync(toId);

        if (fromAcc == null) throw new InvalidOperationException($"Source account with id {fromId} not found.");
        if (toAcc == null) throw new InvalidOperationException($"Destination account with id {toId} not found.");
        if (fromAcc.Balance < amount) throw new InvalidOperationException("Insufficient funds in source account.");

        fromAcc.Balance -= amount;
        toAcc.Balance += amount;

        await _accountRepo.UpdateAsync(fromAcc);
        await _accountRepo.UpdateAsync(toAcc);

        await _transactionRepo.AddAsync(new Transaction
        {
            AccountId = fromAcc.Id,
            Amount = amount,
            Type = "TransferOut"
        });

        await _transactionRepo.AddAsync(new Transaction
        {
            AccountId = toAcc.Id,
            Amount = amount,
            Type = "TransferIn"
        });
    }


    public async Task<int> CreateAccountAsync(int customerId)
    {
        var account = new Account
        {
            AccountNumber = Guid.NewGuid().ToString("N").Substring(0, 20),
            AccountName = $"Account-{customerId}-{DateTime.UtcNow:yyyyMMddHHmmss}",
            Balance = 0m,
            CustomerId = customerId
        };

        await _accountRepo.AddAsync(account);
        return account.Id;
    }

    public async Task<AccountDto> GetAccountAsync(int accountId)
    {
        var acc = await _accountRepo.GetByIdAsync(accountId);
        if (acc == null) throw new InvalidOperationException($"Account with id {accountId} not found.");
        return new AccountDto { Id = acc.Id, AccountNumber = acc.AccountNumber, Balance = acc.Balance };
    }

    public async Task<List<AccountDto>> GetCustomerAccountsAsync(int customerId)
    {
        var all = await _accountRepo.GetAllAsync();
        return all.Where(a => a.CustomerId == customerId)
                  .Select(a => new AccountDto { Id = a.Id, AccountNumber = a.AccountNumber, Balance = a.Balance })
                  .ToList();
    }
}
