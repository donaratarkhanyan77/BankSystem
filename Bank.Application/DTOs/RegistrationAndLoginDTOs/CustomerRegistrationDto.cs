using System.ComponentModel.DataAnnotations;

namespace Bank.Application.DTOs.RegistrationAndLoginDTOs;

public class CustomerRegistrationDto
{
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [RegularExpression(@"^[^@\s]+@[a-z0-9.-]+\.[a-z]{2,}$", ErrorMessage = "Domain must be lowercase (example: user@example.com)")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [RegularExpression(@"^(?=.{8,}$)(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$",
    ErrorMessage = "Password must be at least 8 characters and contain at least one uppercase letter, one lowercase letter, one digit and one special character.")]
    public string Password { get; set; } = string.Empty;

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;
}
