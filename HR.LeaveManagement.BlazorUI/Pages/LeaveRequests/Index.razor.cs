using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.ViewModels.LeaveRequests;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveRequests
{
  public partial class Index
  {
    [Inject] ILeaveRequestService LeaveRequestService { get; set; }
    [Inject] NavigationManager NavigationManager { get; set; }

    public AdminLeaveRequestViewModel Model { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
      Model = await LeaveRequestService.GetAdminLeaveRequests();
    }

    void GoToDetails(int id)
    {
      NavigationManager.NavigateTo($"/leaverequests/details/{id}");
    }
  }
}