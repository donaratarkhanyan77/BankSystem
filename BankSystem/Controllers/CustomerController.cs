using Bank.Application.DTOs.CreateDTOs;
using Bank.Application.Interfaces;
using Bank.Application.DTOs.UpdateDTOs;
using Microsoft.AspNetCore.Mvc;
namespace BankSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService; //dependency injection

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest req)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await _customerService.CreateCustomerAsync(req.FirstName, req.Email);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var customer = await _customerService.GetCustomerAsync(id);
        if (customer == null) return NotFound();
        return Ok(customer);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers = await _customerService.GetAllCustomersAsync();
        return Ok(customers);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int customerId)
    {
        await _customerService.DeleteCustomerAsync(customerId);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerUpdateDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _customerService.UpdateCustomerAsync(id, dto);
        if (!updated) return NotFound();
        return NoContent();
    }


}
