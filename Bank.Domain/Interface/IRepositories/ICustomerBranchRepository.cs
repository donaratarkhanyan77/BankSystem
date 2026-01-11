using System.Collections.Generic;
using System.Threading.Tasks;
using Bank.Domain.Entities;

namespace Bank.Domain.Interface.IRepositories
{
    public interface ICustomerBranchRepository : IBaseRepository<CustomerBranch>
    {
        Task<List<CustomerBranch>> GetByCustomerIdAsync(int customerId);
        Task<List<CustomerBranch>> GetByBranchIdAsync(int branchId);
    }
}
