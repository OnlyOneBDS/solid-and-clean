using HR.LeaveManagement.BlazorUI.ViewModels.LeaveAllocations;

namespace HR.LeaveManagement.BlazorUI.ViewModels.LeaveRequests;

public class EmployeeLeaveRequestViewModel
{
  public List<LeaveAllocationViewModel> LeaveAllocations { get; set; }
  public List<LeaveRequestViewModel> LeaveRequests { get; set; }
}