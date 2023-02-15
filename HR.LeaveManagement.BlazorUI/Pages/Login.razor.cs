using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.ViewModels;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages;

public partial class Login
{
  public LoginViewModel Model { get; set; }
  public string Message { get; set; }

  [Inject]
  public NavigationManager NavigationManager { get; set; }

  [Inject]
  private IAuthenticationService AuthenticationService { get; set; }

  public Login() { }

  protected override void OnInitialized()
  {
    Model = new LoginViewModel();
  }

  protected async Task HandleLogin()
  {
    if (await AuthenticationService.AuthenticateAsync(Model.Email, Model.Password))
    {
      NavigationManager.NavigateTo("/");
    }

    Message = "Invalid username and/or password";
  }
}