using Bank.Domain.Entities;

namespace Bank.Domain.Interface.IRepositories;

public interface IAccountRepository : IBaseRepository<Account>
{
    Task<int> CreateAccount(Account account);
    //update,delete,getallaccounts,getbyId


}
