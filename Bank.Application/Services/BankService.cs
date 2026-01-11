using Bank.Application.Interfaces;
using Bank.Domain.Entities;
using Bank.Domain.Interface.IRepositories;

public class BankService : IBankService
{
    private readonly IAccountRepository _accountRepo;

    public BankService(IAccountRepository repo)
    {
        _accountRepo = repo;
    }

    public async Task DepositAsync(int accountId, decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Amount must be greater than zero.", nameof(amount));

        var account = await _accountRepo.GetByIdAsync(accountId);
        if (account == null) throw new InvalidOperationException($"Account with id {accountId} not found.");

        account.Balance += amount;
        await _accountRepo.UpdateAsync(account);
    }

    public async Task WithdrawAsync(int accountId, decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Amount must be greater than zero.", nameof(amount));

        var account = await _accountRepo.GetByIdAsync(accountId);
        if (account == null) throw new InvalidOperationException($"Account with id {accountId} not found.");
        if (account.Balance < amount) throw new InvalidOperationException("Insufficient funds.");

        account.Balance -= amount;
        await _accountRepo.UpdateAsync(account);
    }

    public async Task TransferAsync(int fromAccountId, int toAccountId, decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Amount must be greater than zero.", nameof(amount));

        var from = await _accountRepo.GetByIdAsync(fromAccountId);
        var to = await _accountRepo.GetByIdAsync(toAccountId);
        if (from == null) throw new InvalidOperationException($"Source account with id {fromAccountId} not found.");
        if (to == null) throw new InvalidOperationException($"Destination account with id {toAccountId} not found.");
        if (from.Balance < amount) throw new InvalidOperationException("Insufficient funds in source account.");

        from.Balance -= amount;
        to.Balance += amount;

        await _accountRepo.UpdateAsync(from);
        await _accountRepo.UpdateAsync(to);
    }
}
