using HR.LeaveManagement.BlazorUI.ViewModels.LeaveTypes;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveTypes
{
  public partial class FormComponent
  {
    [Parameter]
    public bool Disabled { get; set; } = false;

    [Parameter]
    public LeaveTypeViewModel LeaveType { get; set; }

    [Parameter]
    public string ButtonText { get; set; } = "Save";

    [Parameter]
    public EventCallback OnValidSubmit { get; set; }
  }
}