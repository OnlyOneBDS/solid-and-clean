using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.ViewModels.LeaveTypes;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveTypes;

public partial class Edit
{
  [Inject]
  ILeaveTypeService LeaveTypeService { get; set; }

  [Inject]
  NavigationManager NavigationManager { get; set; }

  [Parameter]
  public int id { get; set; }

  public string Message { get; private set; }

  LeaveTypeViewModel leaveType = new LeaveTypeViewModel();

  protected async override Task OnParametersSetAsync()
  {
    leaveType = await LeaveTypeService.GetLeaveTypeDetails(id);
  }

  async Task EditLeaveType()
  {
    var response = await LeaveTypeService.UpdateLeaveType(leaveType, id);

    if (response.Success)
    {
      NavigationManager.NavigateTo("/leavetypes/");
    }

    Message = response.Message;
  }
}