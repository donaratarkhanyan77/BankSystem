using Bank.Domain.Entities;

namespace Bank.Domain.Interface.IRepositories;

public interface IBranchRepository : IBaseRepository<Branch>
{
    Task<Branch?> GetByNameAsync(string name);
}
