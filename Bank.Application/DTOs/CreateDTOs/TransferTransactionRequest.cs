namespace Bank.Application.DTOs.CreateDTOs;

public class TransferTransactionRequest
{
    public int FromAccountId { get; set; }
    public int ToAccountId { get; set; }
    public decimal Amount { get; set; }
}
