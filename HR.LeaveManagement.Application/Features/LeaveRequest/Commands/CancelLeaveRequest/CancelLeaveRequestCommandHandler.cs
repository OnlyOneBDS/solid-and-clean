using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Models.Email;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.CancelLeaveRequest;

public class CancelLeaveRequestCommandHandler : IRequestHandler<CancelLeaveRequestCommand, Unit>
{
  private readonly IEmailSender _emailSender;
  private readonly ILeaveAllocationRepository _leaveAllocationRepository;
  private readonly ILeaveRequestRepository _leaveRequestRepository;

  public CancelLeaveRequestCommandHandler(IEmailSender emailSender, ILeaveAllocationRepository leaveAllocationRepository, ILeaveRequestRepository leaveRequestRepository)
  {
    _emailSender = emailSender;
    _leaveAllocationRepository = leaveAllocationRepository;
    _leaveRequestRepository = leaveRequestRepository;
  }

  public async Task<Unit> Handle(CancelLeaveRequestCommand request, CancellationToken cancellationToken)
  {
    var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

    if (leaveRequest is null)
    {
      throw new NotFoundException(nameof(leaveRequest), request.Id);
    }

    leaveRequest.Cancelled = true;
    await _leaveRequestRepository.UpdateAsync(leaveRequest);

    // If already approved, re-evaluate the employee's allocations for the leave type
    if (leaveRequest.Approved == true)
    {
      int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
      var allocation = await _leaveAllocationRepository.GetUserAllocations(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);

      allocation.NumberOfDays += daysRequested;
      await _leaveAllocationRepository.UpdateAsync(allocation);
    }

    // Send confirmation email
    var email = new EmailMessage
    {
      To = string.Empty, /* Get email from employee record */
      Body = $"Your leave request for {leaveRequest.StartDate:D} to {leaveRequest.EndDate:D} has been cancelled successfully.",
      Subject = "Leave Request Cancelled"
    };

    await _emailSender.SendEmail(email);
    return Unit.Value;
  }
}