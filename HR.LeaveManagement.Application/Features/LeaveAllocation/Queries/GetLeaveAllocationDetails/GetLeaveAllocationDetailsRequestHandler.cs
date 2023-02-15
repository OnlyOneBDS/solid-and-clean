using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;

public class GetLeaveAllocationDetailsRequestHandler : IRequestHandler<GetLeaveAllocationDetailsQuery, LeaveAllocationDetailsDto>
{
  private readonly IMapper _mapper;
  private readonly ILeaveAllocationRepository _leaveAllocationRepository;

  public GetLeaveAllocationDetailsRequestHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
  {
    _mapper = mapper;
    _leaveAllocationRepository = leaveAllocationRepository;
  }

  public async Task<LeaveAllocationDetailsDto> Handle(GetLeaveAllocationDetailsQuery request, CancellationToken cancellationToken)
  {
    var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationWithDetails(request.Id);

    if (leaveAllocation == null)
    {
      throw new NotFoundException(nameof(LeaveAllocation), request.Id);
    }

    return _mapper.Map<LeaveAllocationDetailsDto>(leaveAllocation);
  }
}