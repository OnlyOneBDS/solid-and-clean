using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain;

public class LeaveRequest : BaseEntity
{
  public string RequestingEmployeeId { get; set; } = string.Empty;
  public int LeaveTypeId { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public DateTime DateRequested { get; set; }
  public string RequestComments { get; set; } = string.Empty;
  public bool? Approved { get; set; }
  public bool Cancelled { get; set; }

  public LeaveType? LeaveType { get; set; }
}