using AutoMapper.Configuration.Conventions;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.ViewModels;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages;

public partial class Register
{
  public RegisterViewModel Model { get; set; }
  public string Message { get; set; }

  [Inject]
  public IAuthenticationService AuthenticationService { get; set; }

  [Inject]
  public NavigationManager NavigationManager { get; set; }

  public Register() { }

  protected override void OnInitialized()
  {
    Model = new RegisterViewModel();
  }

  protected async void HandleRegister()
  {
    var result = await AuthenticationService.RegisterAsync(Model.FirstName, Model.LastName, Model.UserName, Model.Email, Model.Password);

    if (result)
    {
      NavigationManager.NavigateTo("/");
    }

    Message = "Something went wrong, please try again";
  }
}