using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace HR.LeaveManagement.BlazorUI.Providers;

public class ApiAuthStateProvider : AuthenticationStateProvider
{
  private readonly ILocalStorageService _localStorage;
  private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

  public ApiAuthStateProvider(ILocalStorageService localStorage)
  {
    _localStorage = localStorage;
    _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
  }

  public override async Task<AuthenticationState> GetAuthenticationStateAsync()
  {
    var user = new ClaimsPrincipal(new ClaimsIdentity());
    var isTokenPresent = await _localStorage.ContainKeyAsync("token");

    if (isTokenPresent == false)
    {
      return new AuthenticationState(user);
    }

    var token = await _localStorage.GetItemAsync<string>("token");
    var jwtSecurityToken = _jwtSecurityTokenHandler.ReadJwtToken(token);

    if (jwtSecurityToken.ValidTo < DateTime.Now)
    {
      await _localStorage.RemoveItemAsync("token");
      return new AuthenticationState(user);
    }

    var claims = await GetClaimsAsync();

    user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));

    return new AuthenticationState(user);
  }

  public async Task LoggedIn()
  {
    var claims = await GetClaimsAsync();
    var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
    var authState = Task.FromResult(new AuthenticationState(user));

    NotifyAuthenticationStateChanged(authState);
  }

  public async Task LoggedOut()
  {
    await _localStorage.RemoveItemAsync("token");

    var anonUser = new ClaimsPrincipal(new ClaimsIdentity());
    var authState = Task.FromResult(new AuthenticationState(anonUser));

    NotifyAuthenticationStateChanged(authState);
  }

  private async Task<List<Claim>> GetClaimsAsync()
  {
    var token = await _localStorage.GetItemAsync<string>("token");
    var jwtSecurityToken = _jwtSecurityTokenHandler.ReadJwtToken(token);
    var claims = jwtSecurityToken.Claims.ToList();

    claims.Add(new Claim(ClaimTypes.Name, jwtSecurityToken.Subject));
    return claims;
  }
}