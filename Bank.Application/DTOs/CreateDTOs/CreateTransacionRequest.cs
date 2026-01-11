namespace Bank.Application.DTOs.CreateDTOs;

public class CreateTransactionRequest
{
    public int AccountId { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Type { get; set; } = "Deposit";

}