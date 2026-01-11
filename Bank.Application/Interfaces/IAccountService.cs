using Bank.Application.DTOs.ResponseDTOs;

namespace Bank.Application.Interfaces;

public interface IAccountService
{
    Task<int> CreateAccountAsync(int customerId);
    Task<AccountDto> GetAccountAsync(int accountId);
    Task<List<AccountDto>> GetCustomerAccountsAsync(int customerId);
    Task<AccountDto> DepositAsync(int accountId, decimal amount);
    Task<AccountDto> WithdrawAsync(int accountId, decimal amount);
    Task TransferAsync(int fromAccountId, int toAccountId, decimal amount);
}