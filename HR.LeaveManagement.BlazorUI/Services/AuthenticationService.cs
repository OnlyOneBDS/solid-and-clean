using Blazored.LocalStorage;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Providers;
using HR.LeaveManagement.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

namespace HR.LeaveManagement.BlazorUI.Services;

public class AuthenticationService : BaseHttpService, IAuthenticationService
{
  private readonly AuthenticationStateProvider _authStateProvider;

  public AuthenticationService(IClient client, ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider) : base(client, localStorage)
  {
    _authStateProvider = authStateProvider;
  }

  public async Task<bool> AuthenticateAsync(string email, string password)
  {
    var authRequest = new AuthRequest { Email = email, Password = password };
    var authResponse = await _client.LoginAsync(authRequest);

    try
    {
      if (authResponse.Token != string.Empty)
      {
        await _localStorage.SetItemAsync("token", authResponse.Token);

        // Set claims in Blazor and login state
        await ((ApiAuthStateProvider)_authStateProvider).LoggedIn();

        return true;
      }

      return false;
    }
    catch (Exception)
    {
      return false;
    }
  }

  public async Task Logout()
  {
    // Remove claims in Blazor and invalidate login state
    await ((ApiAuthStateProvider)_authStateProvider).LoggedOut();
  }

  public async Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password)
  {
    var request = new RegistrationRequest { FirstName = firstName, LastName = lastName, UserName = userName, Email = email, Password = password };
    var response = await _client.RegisterAsync(request);

    if (!string.IsNullOrEmpty(response.UserId))
    {
      return true;
    }

    return false;
  }
}