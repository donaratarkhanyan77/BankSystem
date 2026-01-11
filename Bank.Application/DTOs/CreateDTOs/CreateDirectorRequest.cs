using System.ComponentModel.DataAnnotations;

namespace Bank.Application.DTOs.CreateDTOs;

public class CreateDirectorRequest
{

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Phone is required")]
    [RegularExpression(@"^\+?[0-9\s\-\(\)]{6,20}$", ErrorMessage = "Invalid phone number")]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [RegularExpression(@"^[^@\s]+@[a-z0-9.-]+\.[a-z]{2,}$",ErrorMessage = "Domain must be lowercase (example: user@example.com)")]
    public string Email { get; set; } = null!;


    [Required]
    public int BranchId { get; set; }
}