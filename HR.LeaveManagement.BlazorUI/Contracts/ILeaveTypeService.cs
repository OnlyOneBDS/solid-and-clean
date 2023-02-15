using HR.LeaveManagement.BlazorUI.Services.Base;
using HR.LeaveManagement.BlazorUI.ViewModels.LeaveTypes;

namespace HR.LeaveManagement.BlazorUI.Contracts;

public interface ILeaveTypeService
{
  Task<List<LeaveTypeViewModel>> GetLeaveTypes();
  Task<LeaveTypeViewModel> GetLeaveTypeDetails(int id);
  Task<Response<Guid>> CreateLeaveType(LeaveTypeViewModel leaveType);
  Task<Response<Guid>> UpdateLeaveType(LeaveTypeViewModel leaveType, int id);
  Task<Response<Guid>> DeleteLeaveType(int id);
}