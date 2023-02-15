namespace HR.LeaveManagement.BlazorUI.ViewModels.LeaveAllocations;

public class ViewLeaveAllocationViewModel
{
  public string EmployeeId { get; set; }
  public List<LeaveAllocationViewModel> LeaveAllocations { get; set; }
}