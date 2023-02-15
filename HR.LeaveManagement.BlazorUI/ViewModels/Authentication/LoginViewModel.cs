using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.BlazorUI.ViewModels.Authentication;

public class LoginViewModel
{
  [EmailAddress]
  [Required]
  public string Email { get; set; }

  [DataType(DataType.Password)]
  [Required]
  public string Password { get; set; }

  public string ReturnUrl { get; set; }
}