namespace Bank.Application.DTOs.ResponseDTOs;

public class AccountResponseDto
{
    public int Id { get; set; }

    public string AccountName { get; set; } = string.Empty;

    public string AccountNumber { get; set; } = string.Empty;

    public decimal Balance { get; set; }

}
