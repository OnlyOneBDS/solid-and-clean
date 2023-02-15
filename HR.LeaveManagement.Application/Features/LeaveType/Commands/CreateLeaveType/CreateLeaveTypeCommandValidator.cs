using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
{
  private ILeaveTypeRepository _leaveTypeRepository;

  public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
  {
    RuleFor(p => p.Name)
      .NotEmpty().WithMessage("{PropertyName} is required")
      .NotNull()
      .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

    RuleFor(p => p.DefaultDays)
      .GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1")
      .LessThan(100).WithMessage("{PropertyName} cannot exceed 100");

    RuleFor(q => q)
      .MustAsync(LeaveTypeNameUnique)
      .WithMessage("Leave type already exists");

    _leaveTypeRepository = leaveTypeRepository;
  }

  private Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken cancellationToken)
  {
    return _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
  }
}