using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;
using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequests;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.MappingProfiles;

public class LeaveRequestProfile : Profile
{
  public LeaveRequestProfile()
  {
    // Commands
    CreateMap<CreateLeaveRequestCommand, LeaveRequest>();
    CreateMap<UpdateLeaveRequestCommand, LeaveRequest>();

    // Queries
    CreateMap<LeaveRequestDto, LeaveRequest>().ReverseMap();
    CreateMap<LeaveRequestDetailsDto, LeaveRequest>().ReverseMap();
    CreateMap<LeaveRequest, LeaveRequestDetailsDto>();
  }
}