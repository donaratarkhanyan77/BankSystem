using Bank.Application.DTOs.ResponseDTOs;
using Bank.Application.DTOs.UpdateDTOs;

namespace Bank.Application.Interfaces;

public interface ICustomerService
{
    Task<int> CreateCustomerAsync(string fullName, string email);
    Task<CustomerDto> GetCustomerAsync(int id);
    Task<List<CustomerDto>> GetAllCustomersAsync();
    Task DeleteCustomerAsync(int customerId);
    Task<bool> UpdateCustomerAsync(int id, CustomerUpdateDTO updateDto);
}

