using Bank.Application.Interfaces.IServices;
using Bank.Domain.Entities;
using System.Linq;
using Bank.Domain.Interface.IRepositories;


namespace Bank.Application.Services;

public class CustomerBranchService : ICustomerBranchService
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerBranchService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Branch>> GetBranchesByCustomerAsync(int customerId)
    {
        var customer = await _unitOfWork.Customers.GetByIdAsync(customerId);
        if (customer == null)
            throw new InvalidOperationException($"Customer with id {customerId} not found.");

        var list = await _unitOfWork.CustomerBranches.GetByCustomerIdAsync(customerId);
        return list.Select(x => x.Branch).ToList();
    }

    public async Task<List<Customer>> GetCustomersByBranchAsync(int branchId)
    {
        var branch = await _unitOfWork.Branches.GetByIdAsync(branchId);
        if (branch == null)
            throw new InvalidOperationException($"Branch with id {branchId} not found.");

        var list = await _unitOfWork.CustomerBranches.GetByBranchIdAsync(branchId);
        return list.Select(x => x.Customer).ToList();
    }


    public async Task AssignCustomerToBranchAsync(int customerId, int branchId)
    {
        // Ensure customer exists
        var customer = await _unitOfWork.Customers.GetByIdAsync(customerId)
                       ?? throw new InvalidOperationException($"Customer {customerId} not found");

        // Ensure branch exists
        var branch = await _unitOfWork.Branches.GetByIdAsync(branchId)
                    ?? throw new InvalidOperationException($"Branch {branchId} not found");

        // Check if assignment already exists
        var existing = await _unitOfWork.CustomerBranches.GetByCustomerIdAsync(customerId);
        if (existing.Any(cb => cb.BranchId == branchId))
            throw new ArgumentException($"Customer {customerId} is already assigned to branch {branchId}");

        // Assign
        await _unitOfWork.CustomerBranches.AddAsync(new CustomerBranch
        {
            CustomerId = customerId,
            BranchId = branchId
        });

        await _unitOfWork.SaveChangesAsync();
    }

}