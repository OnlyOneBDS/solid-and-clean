using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.ViewModels.LeaveRequests;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveRequests
{
  public partial class Details
  {
    [Inject] ILeaveRequestService LeaveRequestService { get; set; }
    [Inject] NavigationManager NavigationManager { get; set; }
    [Parameter] public int Id { get; set; }

    public LeaveRequestViewModel Model { get; set; }

    string ClassName;
    string HeadingText;

    protected override async Task OnInitializedAsync()
    {
      if (Model.Approved == null)
      {
        ClassName = "warning";
        HeadingText = "Pending";
      }
      else if (Model.Approved == true)
      {
        ClassName = "success";
        HeadingText = "Approved";
      }
      else
      {
        ClassName = "danger";
        HeadingText = "Rejected";
      }
    }

    protected override async Task OnParametersSetAsync()
    {
      Model = await LeaveRequestService.GetLeaveRequest(Id);
    }

    async Task ChangeApproval(bool approvalStatus)
    {
      await LeaveRequestService.ApproveLeaveRequest(id: Id, approvalStatus);
      NavigationManager.NavigateTo("/leaverequests");
    }
  }
}