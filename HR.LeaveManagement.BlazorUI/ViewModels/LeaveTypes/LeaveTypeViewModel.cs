using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.BlazorUI.ViewModels.LeaveTypes;

public class LeaveTypeViewModel
{
  public int Id { get; set; }

  [Required]
  public string Name { get; set; }

  [Display(Name = "Default Number of Days")]
  [Required]
  public int DefaultDays { get; set; }
}