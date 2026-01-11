using Bank.Application.DTOs.ResponseDTOs;
using Bank.Application.Interfaces;
using Bank.Application.DTOs.UpdateDTOs;
using Bank.Domain.Entities;
using Bank.Domain.Interface.IRepositories;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repo;

    public CustomerService(ICustomerRepository repo)
    {
        _repo = repo;
    }

    public async Task<int> CreateCustomerAsync(string firstName, string email)
    {
        var customer = new Customer
        {
            FirstName = firstName,
            Email = email
        };

        await _repo.AddAsync(customer);
        return customer.Id;
    }

    public async Task DeleteCustomerAsync(int customerId)
    {
        var customer = await _repo.GetByIdAsync(customerId);
        if (customer == null) return;
        await _repo.DeleteAsync(customer);
    }

    public async Task<CustomerDto> GetCustomerAsync(int id)
    {
        var c = await _repo.GetByIdAsync(id);
        if (c == null) return null!;
        return new CustomerDto
        {
            Id = c.Id,
            FirstName = c.FirstName,
            LastName = c.LastName,
            Email = c.Email,
            Phone = c.Phone
        };
    }

    public async Task<List<CustomerDto>> GetAllCustomersAsync()
    {
        var all = await _repo.GetAllAsync();
        return all.Select(c => new CustomerDto
        {
            Id = c.Id,
            FirstName = c.FirstName,
            LastName = c.LastName,
            Email = c.Email,
            Phone = c.Phone
        }).ToList();
    }

    public async Task<bool> UpdateCustomerAsync(int id, CustomerUpdateDTO updateDto)
    {
        var customer = await _repo.GetByIdAsync(id);
        if (customer == null) return false;

        customer.FirstName = updateDto.FirstName;
        customer.LastName = updateDto.LastName;
        customer.Phone = updateDto.Phone ?? customer.Phone;
        customer.Email = updateDto.Email;

        await _repo.UpdateAsync(customer);
        return true;
    }
}
