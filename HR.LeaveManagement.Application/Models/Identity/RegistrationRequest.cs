using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.Application.Models.Identity;

public class RegistrationRequest
{
  [Required]
  public string FirstName { get; set; }

  [Required]
  public string LastName { get; set; }

  [EmailAddress]
  [Required]
  public string Email { get; set; }

  [MinLength(6)]
  [Required]
  public string UserName { get; set; }

  [MinLength(6)]
  [Required]
  public string Password { get; set; }
}