using AutoMapper;
using HR.LeaveManagement.BlazorUI.Services.Base;
using HR.LeaveManagement.BlazorUI.ViewModels;
using HR.LeaveManagement.BlazorUI.ViewModels.LeaveAllocations;
using HR.LeaveManagement.BlazorUI.ViewModels.LeaveRequests;
using HR.LeaveManagement.BlazorUI.ViewModels.LeaveTypes;

namespace HR.LeaveManagement.BlazorUI.MappingProfiles;

public class MappingConfig : Profile
{
  public MappingConfig()
  {
    // LeaveAllocations
    CreateMap<LeaveAllocationDto, LeaveAllocationViewModel>().ReverseMap();
    CreateMap<LeaveAllocationDetailsDto, LeaveAllocationViewModel>().ReverseMap();
    CreateMap<CreateLeaveAllocationCommand, LeaveAllocationViewModel>().ReverseMap();
    CreateMap<UpdateLeaveAllocationCommand, LeaveAllocationViewModel>().ReverseMap();

    // LeaveRequests
    CreateMap<LeaveRequestDto, LeaveRequestViewModel>()
      .ForMember(lr => lr.DateRequested, options => options.MapFrom(m => m.DateRequested.DateTime))
      .ForMember(lr => lr.StartDate, options => options.MapFrom(m => m.StartDate.DateTime))
      .ForMember(lr => lr.EndDate, options => options.MapFrom(m => m.EndDate.DateTime))
      .ReverseMap();
    CreateMap<LeaveRequestDetailsDto, LeaveRequestViewModel>()
      .ForMember(lr => lr.DateRequested, options => options.MapFrom(m => m.DateRequested.DateTime))
      .ForMember(lr => lr.StartDate, options => options.MapFrom(m => m.StartDate.DateTime))
      .ForMember(lr => lr.EndDate, options => options.MapFrom(m => m.EndDate.DateTime))
      .ReverseMap();
    CreateMap<CreateLeaveRequestCommand, LeaveRequestViewModel>().ReverseMap();
    CreateMap<UpdateLeaveRequestCommand, LeaveRequestViewModel>().ReverseMap();

    // LeaveTypes
    CreateMap<LeaveTypeDto, LeaveTypeViewModel>().ReverseMap();
    CreateMap<LeaveTypeDetailsDto, LeaveTypeViewModel>().ReverseMap();
    CreateMap<CreateLeaveTypeCommand, LeaveTypeViewModel>().ReverseMap();
    CreateMap<UpdateLeaveTypeCommand, LeaveTypeViewModel>().ReverseMap();

    // Employees
    CreateMap<EmployeeViewModel, Employee>().ReverseMap();
  }
}