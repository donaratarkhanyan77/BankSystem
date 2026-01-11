using Bank.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService; //dependency injection

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("deposit")]
    public async Task<IActionResult> Deposit([FromBody] DepositRequest req)
    {
        var result = await _accountService.DepositAsync(req.AccountId, req.Amount);
        return Ok(result);
    }

    [HttpPost("withdraw")]
    public async Task<IActionResult> Withdraw([FromBody] WithdrawRequest req)
    {
        var result = await _accountService.WithdrawAsync(req.AccountId, req.Amount);
        return Ok(result);
    }

    [HttpPost("transfer")]
    public async Task<IActionResult> Transfer([FromBody] TransferRequest req)
    {
        await _accountService.TransferAsync(req.FromAccountId, req.ToAccountId, req.Amount);
        return Ok();
    }
}

public record DepositRequest(int AccountId, decimal Amount);
public record WithdrawRequest(int AccountId, decimal Amount);
public record TransferRequest(int FromAccountId, int ToAccountId, decimal Amount);