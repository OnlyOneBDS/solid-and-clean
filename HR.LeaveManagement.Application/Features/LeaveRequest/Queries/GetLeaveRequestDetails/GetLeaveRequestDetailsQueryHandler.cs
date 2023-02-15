using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;

public class GetLeaveRequestDetailsQueryHandler : IRequestHandler<GetLeaveRequestDetailsQuery, LeaveRequestDetailsDto>
{
  private readonly IMapper _mapper;
  private readonly ILeaveRequestRepository _leaveRequestRepository;

  public GetLeaveRequestDetailsQueryHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepository)
  {
    _leaveRequestRepository = leaveRequestRepository;
    _mapper = mapper;
  }

  public async Task<LeaveRequestDetailsDto> Handle(GetLeaveRequestDetailsQuery request, CancellationToken cancellationToken)
  {
    var leaveRequest = _mapper.Map<LeaveRequestDetailsDto>(await _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id));

    if (leaveRequest == null)
    {
      throw new NotFoundException(nameof(LeaveRequest), request.Id);
    }

    // Add Employee details as needed

    return leaveRequest;
  }
}