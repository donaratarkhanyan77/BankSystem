using System.ComponentModel.DataAnnotations;

namespace Bank.Application.DTOs.UpdateDTOs;

public class CustomerUpdateDTO
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last Name is required.")]
    [StringLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Phone is required")]
    [RegularExpression(@"^\+?[0-9\s\-\(\)]{6,20}$", ErrorMessage = "Invalid phone number")]
    public string? Phone { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [RegularExpression(@"^[^@\s]+@[a-z0-9.-]+\.[a-z]{2,}$", ErrorMessage = "Domain must be lowercase (example: user@example.com)")]
    public string Email { get; set; } = string.Empty;
}
