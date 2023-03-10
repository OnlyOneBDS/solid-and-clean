using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.Models.Identity;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;

public class LeaveRequestDetailsDto
{
  public int Id { get; set; }
  public string RequestingEmployeeId { get; set; } = string.Empty;
  public int LeaveTypeId { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public DateTime DateRequested { get; set; }
  public string RequestComments { get; set; } = string.Empty;
  public DateTime? DateActioned { get; set; }
  public bool? Approved { get; set; }
  public bool Cancelled { get; set; }

  public Employee? Employee { get; set; }
  public LeaveTypeDto? LeaveType { get; set; }
}