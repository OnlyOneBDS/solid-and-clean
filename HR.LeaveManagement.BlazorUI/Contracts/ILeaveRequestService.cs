using HR.LeaveManagement.BlazorUI.Services.Base;
using HR.LeaveManagement.BlazorUI.ViewModels.LeaveRequests;

namespace HR.LeaveManagement.BlazorUI.Contracts;

public interface ILeaveRequestService
{
  Task<AdminLeaveRequestViewModel> GetAdminLeaveRequests();
  Task<EmployeeLeaveRequestViewModel> GetUserLeaveRequests();
  Task<Response<Guid>> CancelLeaveRequest(int id);
  Task<Response<Guid>> CreateLeaveRequest(LeaveRequestViewModel leaveRequest);
  Task<LeaveRequestViewModel> GetLeaveRequest(int id);
  Task DeleteLeaveRequest(int id);
  Task ApproveLeaveRequest(int id, bool approved);
}