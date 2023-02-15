using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.ViewModels.LeaveTypes;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveTypes;

public partial class Details
{
  [Inject]
  ILeaveTypeService LeaveTypeService { get; set; }

  [Parameter]
  public int id { get; set; }

  LeaveTypeViewModel leaveType = new();

  protected async override Task OnParametersSetAsync()
  {
    leaveType = await LeaveTypeService.GetLeaveTypeDetails(id);
  }
}