using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.BlazorUI.ViewModels.Authentication;

public class RegisterViewModel
{
  [Required]
  public string FirstName { get; set; }

  [Required]
  public string LastName { get; set; }

  [EmailAddress]
  [Required]
  public string Email { get; set; }

  [Required]
  public string UserName { get; set; }

  [DataType(DataType.Password)]
  [Required]
  public string Password { get; set; }
}