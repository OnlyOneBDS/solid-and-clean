using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.ViewModels.LeaveRequests;
using HR.LeaveManagement.BlazorUI.ViewModels.LeaveTypes;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveRequests
{
  public partial class Create
  {
    [Inject] ILeaveRequestService LeaveRequestService { get; set; }
    [Inject] ILeaveTypeService LeaveTypeService { get; set; }
    [Inject] NavigationManager NavigationManager { get; set; }

    List<LeaveTypeViewModel> LeaveTypes { get; set; } = new();
    LeaveRequestViewModel LeaveRequest { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
      LeaveTypes = await LeaveTypeService.GetLeaveTypes();
    }

    private async void HandleValidSubmit()
    {
      // Perform form submission here
      await LeaveRequestService.CreateLeaveRequest(LeaveRequest);
      NavigationManager.NavigateTo("/leaverequests");
    }
  }
}