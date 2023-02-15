using AutoMapper;
using Blazored.LocalStorage;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Services.Base;
using HR.LeaveManagement.BlazorUI.ViewModels.LeaveAllocations;
using HR.LeaveManagement.BlazorUI.ViewModels.LeaveRequests;

namespace HR.LeaveManagement.BlazorUI.Services;

public class LeaveRequestService : BaseHttpService, ILeaveRequestService
{
  private readonly IMapper _mapper;

  public LeaveRequestService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
  {
    _mapper = mapper;
  }

  public async Task ApproveLeaveRequest(int id, bool approved)
  {
    try
    {
      var request = new ChangeLeaveRequestApprovalCommand { Approved = approved, Id = id };
      await _client.UpdateApprovalAsync(request);
    }
    catch (Exception)
    {
      throw;
    }
  }

  public async Task<Response<Guid>> CancelLeaveRequest(int id)
  {
    try
    {
      var response = new Response<Guid>();
      var request = new CancelLeaveRequestCommand { Id = id };

      await _client.CancelRequestAsync(request);
      return response;
    }
    catch (ApiException ex)
    {
      return ConvertApiExceptions<Guid>(ex);
    }
  }

  public async Task<Response<Guid>> CreateLeaveRequest(LeaveRequestViewModel leaveRequest)
  {
    try
    {
      var response = new Response<Guid>();
      CreateLeaveRequestCommand createLeaveRequest = _mapper.Map<CreateLeaveRequestCommand>(leaveRequest);

      await _client.LeaveRequestsPOSTAsync(createLeaveRequest);
      return response;
    }
    catch (ApiException ex)
    {
      return ConvertApiExceptions<Guid>(ex);
    }
  }

  public Task DeleteLeaveRequest(int id)
  {
    throw new NotImplementedException();
  }

  public async Task<AdminLeaveRequestViewModel> GetAdminLeaveRequests()
  {
    var leaveRequests = await _client.LeaveRequestsAllAsync(isLoggedInUser: false);

    var adminLeaveRequests = new AdminLeaveRequestViewModel
    {
      TotalRequests = leaveRequests.Count,
      ApprovedRequests = leaveRequests.Count(q => q.Approved == true),
      PendingRequests = leaveRequests.Count(q => q.Approved == null),
      RejectedRequests = leaveRequests.Count(q => q.Approved == false),
      LeaveRequests = _mapper.Map<List<LeaveRequestViewModel>>(leaveRequests)
    };

    return adminLeaveRequests;
  }

  public async Task<LeaveRequestViewModel> GetLeaveRequest(int id)
  {
    await AddBearerToken();
    var leaveRequest = await _client.LeaveRequestsGETAsync(id);

    return _mapper.Map<LeaveRequestViewModel>(leaveRequest);
  }

  public async Task<EmployeeLeaveRequestViewModel> GetUserLeaveRequests()
  {
    await AddBearerToken();
    var leaveRequests = await _client.LeaveRequestsAllAsync(isLoggedInUser: true);
    var allocations = await _client.LeaveAllocationsAllAsync(isLoggedInUser: true);

    var model = new EmployeeLeaveRequestViewModel
    {
      LeaveAllocations = _mapper.Map<List<LeaveAllocationViewModel>>(allocations),
      LeaveRequests = _mapper.Map<List<LeaveRequestViewModel>>(leaveRequests)
    };

    return model;
  }
}