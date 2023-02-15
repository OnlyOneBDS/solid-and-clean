using System.Security.Claims;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Models.Identity;
using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace HR.LeaveManagement.Identity.Services;

public class UserService : IUserService
{
  private readonly UserManager<ApplicationUser> _userManager;
  private readonly IHttpContextAccessor _httpContext;

  public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContext)
  {
    _userManager = userManager;
    _httpContext = httpContext;
  }

  public string UserId { get => _httpContext.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier); }

  public async Task<Employee> GetEmployee(string userId)
  {
    var employee = await _userManager.FindByIdAsync(userId);

    return new Employee
    {
      Id = employee.Id,
      Email = employee.Email,
      FirstName = employee.FirstName,
      LastName = employee.LastName
    };
  }

  public async Task<List<Employee>> GetEmployees()
  {
    var employees = await _userManager.GetUsersInRoleAsync("Employee");

    return employees.Select(employee => new Employee
    {
      Id = employee.Id,
      Email = employee.Email,
      FirstName = employee.FirstName,
      LastName = employee.LastName
    }).ToList();
  }
}