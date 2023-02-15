using Blazored.Toast.Services;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.ViewModels.LeaveTypes;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveTypes;

public partial class Index
{
  [Inject] public ILeaveAllocationService LeaveAllocationService { get; set; }
  [Inject] public ILeaveTypeService LeaveTypeService { get; set; }
  [Inject] public IToastService ToastService { get; set; }
  [Inject] public NavigationManager NavigationManager { get; set; }

  public List<LeaveTypeViewModel> LeaveTypes { get; set; }
  public string Message { get; set; } = string.Empty;

  protected override async Task OnInitializedAsync()
  {
    LeaveTypes = await LeaveTypeService.GetLeaveTypes();
  }

  protected void CreateLeaveType()
  {
    NavigationManager.NavigateTo("/leavetypes/create");
  }

  protected async Task AllocateLeaveType(int id)
  {
    await LeaveAllocationService.CreateLeaveAllocations(id);
  }

  protected void DetailsLeaveType(int id)
  {
    NavigationManager.NavigateTo($"/leavetypes/details/{id}");
  }

  protected void EditLeaveType(int id)
  {
    NavigationManager.NavigateTo($"/leavetypes/edit/{id}");
  }

  protected async Task DeleteLeaveType(int id)
  {
    var response = await LeaveTypeService.DeleteLeaveType(id);

    if (response.Success)
    {
      ToastService.ShowSuccess("Leave Type deleted successfully");
      await OnInitializedAsync();
    }
    else
    {
      Message = response.Message;
    }
  }
}