using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Models.Email;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval;

public class ChangeLeaveRequestApprovalCommandHandler : IRequestHandler<ChangeLeaveRequestApprovalCommand, Unit>
{
  private readonly IMapper _mapper;
  private readonly IEmailSender _emailSender;
  private readonly ILeaveAllocationRepository _leaveAllocationRepository;
  private readonly ILeaveRequestRepository _leaveRequestRepository;
  private readonly ILeaveTypeRepository _leaveTypeRepository;

  public ChangeLeaveRequestApprovalCommandHandler(IMapper mapper, IEmailSender emailSender, ILeaveAllocationRepository leaveAllocationRepository, ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository)
  {
    _mapper = mapper;
    _emailSender = emailSender;
    _leaveAllocationRepository = leaveAllocationRepository;
    _leaveRequestRepository = leaveRequestRepository;
    _leaveTypeRepository = leaveTypeRepository;
  }

  public async Task<Unit> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
  {
    var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

    if (leaveRequest is null)
    {
      throw new NotFoundException(nameof(LeaveRequest), request.Id);
    }

    leaveRequest.Approved = request.Approved;
    await _leaveRequestRepository.UpdateAsync(leaveRequest);

    // If request is approved, get and update the employee's allocations
    if (request.Approved)
    {
      int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
      var allocation = await _leaveAllocationRepository.GetUserAllocations(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);

      allocation.NumberOfDays -= daysRequested;
    }

    // Send confirmation email
    var email = new EmailMessage
    {
      To = string.Empty, /* Get email from employee record */
      Body = $"The approval status for your leave request for {leaveRequest.StartDate:D} to {leaveRequest.EndDate:D} has been updated.",
      Subject = "Leave Request Approval Status Updated"
    };

    await _emailSender.SendEmail(email);
    return Unit.Value;
  }
}