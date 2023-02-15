using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
{
  private readonly ILeaveTypeRepository _leaveTypeRepository;

  public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
  {
    RuleFor(p => p.Id)
      .NotNull()
      .MustAsync(LeaveTypeMustExist);

    RuleFor(p => p.Name)
      .NotNull()
      .NotEmpty().WithMessage("{PropertyName} is required")
      .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

    RuleFor(p => p.DefaultDays)
      .GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1")
      .LessThan(100).WithMessage("{PropertyName} cannot exceed 100");

    RuleFor(q => q)
      .MustAsync(LeaveTypeNameUnique).WithMessage("Leave type already exists");

    this._leaveTypeRepository = leaveTypeRepository;
  }

  private async Task<bool> LeaveTypeMustExist(int id, CancellationToken cancellationToken)
  {
    var leaveType = await _leaveTypeRepository.GetByIdAsync(id);
    return leaveType != null;
  }

  private async Task<bool> LeaveTypeNameUnique(UpdateLeaveTypeCommand command, CancellationToken cancellationToken)
  {
    return await _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
  }
}