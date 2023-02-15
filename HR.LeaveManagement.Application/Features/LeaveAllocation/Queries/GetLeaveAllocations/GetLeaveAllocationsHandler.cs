using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;

public class GetLeaveAllocationsHandler : IRequestHandler<GetLeaveAllocationsQuery, List<LeaveAllocationDto>>
{
  private readonly IMapper _mapper;
  private readonly ILeaveAllocationRepository _leaveAllocationRepository;

  public GetLeaveAllocationsHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
  {
    _mapper = mapper;
    _leaveAllocationRepository = leaveAllocationRepository;
  }

  public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationsQuery request, CancellationToken cancellationToken)
  {
    // To Add later
    // - Get records for specific user

    // - Get allocations per employee
    var leaveAllocations = await _leaveAllocationRepository.GetLeaveAllocationsWithDetails();
    var allocations = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);

    // Return allocations
    return allocations;
  }
}