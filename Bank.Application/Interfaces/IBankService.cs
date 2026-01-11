namespace Bank.Application.Interfaces;

public interface IBankService
{
    Task DepositAsync(int accountId, decimal amount);
    Task WithdrawAsync(int accountId, decimal amount);
    Task TransferAsync(int fromAccountId, int toAccountId, decimal amount);
}

