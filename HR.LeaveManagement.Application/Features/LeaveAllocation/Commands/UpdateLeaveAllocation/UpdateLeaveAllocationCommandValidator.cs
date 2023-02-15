using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;

public class UpdateLeaveAllocationCommandValidator : AbstractValidator<UpdateLeaveAllocationCommand>
{
  private readonly ILeaveAllocationRepository _leaveAllocationRepository;
  private readonly ILeaveTypeRepository _leaveTypeRepository;

  public UpdateLeaveAllocationCommandValidator(ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository)
  {
    RuleFor(p => p.NumberOfDays)
      .GreaterThan(0).WithMessage("{PropertyName} must greater than {ComparisonValue}");

    RuleFor(p => p.Period)
      .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be after {ComparisonValue}");

    RuleFor(p => p.LeaveTypeId)
      .GreaterThan(0)
      .MustAsync(LeaveTypeMustExist)
      .WithMessage("{PropertyName} does not exist.");

    RuleFor(p => p.Id)
      .NotNull()
      .MustAsync(LeaveAllocationMustExist)
      .WithMessage("{PropertyName} must be present");

    _leaveAllocationRepository = leaveAllocationRepository;
    _leaveTypeRepository = leaveTypeRepository;
  }

  private async Task<bool> LeaveTypeMustExist(int id, CancellationToken cancellationToken)
  {
    var leaveType = await _leaveTypeRepository.GetByIdAsync(id);
    return leaveType != null;
  }

  private async Task<bool> LeaveAllocationMustExist(int id, CancellationToken cancellationToken)
  {
    var leaveAllocation = await _leaveAllocationRepository.GetByIdAsync(id);
    return leaveAllocation != null;
  }
}