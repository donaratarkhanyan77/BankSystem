using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Bank.Application.Interfaces.IServices;

namespace Bank.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerBranchController : ControllerBase
{
    private readonly ICustomerBranchService _customerBranchService;
    private readonly IMapper _mapper;

    public CustomerBranchController(ICustomerBranchService customerBranchService, IMapper mapper)
    {
        _customerBranchService = customerBranchService;
        _mapper = mapper;
    }



}