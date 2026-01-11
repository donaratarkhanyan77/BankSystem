using System.ComponentModel.DataAnnotations;

namespace Bank.Application.DTOs.CreateDTOs;

public class CreateBranchRequest
{
    [Required(ErrorMessage = "Branch name is required.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Branch name must be between 2 and 100 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Address is required.")]
    [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = "Phone is required")]
    [RegularExpression(@"^\+?[0-9\s\-\(\)]{6,20}$", ErrorMessage = "Invalid phone number")]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [RegularExpression(@"^[^@\s]+@[a-z0-9.-]+\.[a-z]{2,}$", ErrorMessage = "Domain must be lowercase (example: user@example.com)")]
    public string Email { get; set; } = null!;

}