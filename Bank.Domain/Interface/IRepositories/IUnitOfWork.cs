using System;
using System.Threading.Tasks;

namespace Bank.Domain.Interface.IRepositories;

public interface IUnitOfWork : IDisposable
{
    IAccountRepository Accounts { get; }
    ICustomerRepository Customers { get; }
    ITransactionRepository Transactions { get; }
    ICustomerProfileRepository CustomerProfiles { get; }
    IBranchRepository Branches { get; }
    ICustomerBranchRepository CustomerBranches { get; }
    IDirectorRepository Directors { get; }

    Task<int> SaveChangesAsync();
    Task<int> CompleteAsync();
}