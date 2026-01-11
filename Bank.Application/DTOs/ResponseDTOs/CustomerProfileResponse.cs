namespace Bank.Application.DTOs.ResponseDTOs;

public class CustomerProfileResponse
{
    public string Address { get; set; } = null!;
    public string PassportNumber { get; set; } = null!;  
    
    public int DateOfBirth { get; set; }
}
