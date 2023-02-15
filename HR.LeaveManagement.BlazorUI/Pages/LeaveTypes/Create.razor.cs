using Blazored.Toast.Services;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.ViewModels.LeaveTypes;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveTypes;

public partial class Create
{
  [Inject] NavigationManager NavigationManager { get; set; }
  [Inject] ILeaveTypeService LeaveTypeService { get; set; }
  [Inject] IToastService ToastService { get; set; }

  LeaveTypeViewModel leaveType = new LeaveTypeViewModel();
  public string Message { get; private set; }

  async Task CreateLeaveType()
  {
    var response = await LeaveTypeService.CreateLeaveType(leaveType);

    if (response.Success)
    {
      ToastService.ShowSuccess("Leave Type create successfully");
      NavigationManager.NavigateTo("/leavetypes");
    }

    Message = response.Message;
  }
}