using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.ViewModels.LeaveRequests;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveRequests;

public partial class Employee
{
  [Inject] ILeaveRequestService LeaveRequestService { get; set; }
  [Inject] IJSRuntime js { get; set; }
  [Inject] NavigationManager NavigationManager { get; set; }

  public EmployeeLeaveRequestViewModel Model { get; set; } = new();
  public string Message { get; set; } = string.Empty;

  protected override async Task OnInitializedAsync()
  {
    Model = await LeaveRequestService.GetUserLeaveRequests();
  }

  async Task CancelRequestAsync(int id)
  {
    var confirm = await js.InvokeAsync<bool>("confirm", "Do you want to cancel this request?");

    if (confirm)
    {
      var response = await LeaveRequestService.CancelLeaveRequest(id);

      if (response.Success)
      {
        StateHasChanged();
      }
      else
      {
        Message = response.Message;
      }
    }
  }
}