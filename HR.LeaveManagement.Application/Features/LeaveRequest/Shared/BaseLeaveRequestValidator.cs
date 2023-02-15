using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Shared;

public class BaseLeaveRequestValidator : AbstractValidator<BaseLeaveRequest>
{
  private readonly ILeaveTypeRepository _leaveTypeRepository;

  public BaseLeaveRequestValidator(ILeaveTypeRepository leaveTypeRepository)
  {
    RuleFor(p => p.LeaveTypeId)
      .GreaterThan(0)
      .MustAsync(LeaveTypeMustExist).WithMessage("{PropertyName} does not exist.");

    RuleFor(p => p.StartDate)
      .LessThan(p => p.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");

    RuleFor(p => p.EndDate)
      .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}");

    _leaveTypeRepository = leaveTypeRepository;
  }

  private async Task<bool> LeaveTypeMustExist(int id, CancellationToken cancellationToken)
  {
    var leaveType = await _leaveTypeRepository.GetByIdAsync(id);
    return leaveType != null;
  }
}