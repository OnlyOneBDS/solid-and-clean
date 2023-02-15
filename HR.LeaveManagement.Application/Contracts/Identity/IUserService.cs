using HR.LeaveManagement.Application.Models.Identity;

namespace HR.LeaveManagement.Application.Contracts.Identity;

public interface IUserService
{
  public string UserId { get; }
  Task<List<Employee>> GetEmployees();
  Task<Employee> GetEmployee(string userId);
}