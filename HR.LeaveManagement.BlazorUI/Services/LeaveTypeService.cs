using AutoMapper;
using Blazored.LocalStorage;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Services.Base;
using HR.LeaveManagement.BlazorUI.ViewModels.LeaveTypes;

namespace HR.LeaveManagement.BlazorUI.Services;

public class LeaveTypeService : BaseHttpService, ILeaveTypeService
{
  private readonly IMapper _mapper;

  public LeaveTypeService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
  {
    _mapper = mapper;
  }

  public async Task<LeaveTypeViewModel> GetLeaveTypeDetails(int id)
  {
    await AddBearerToken();
    var leaveType = await _client.LeaveTypesGETAsync(id);
    return _mapper.Map<LeaveTypeViewModel>(leaveType);
  }

  public async Task<List<LeaveTypeViewModel>> GetLeaveTypes()
  {
    await AddBearerToken();
    var leaveTypes = await _client.LeaveTypesAllAsync();
    return _mapper.Map<List<LeaveTypeViewModel>>(leaveTypes);
  }

  public async Task<Response<Guid>> CreateLeaveType(LeaveTypeViewModel leaveType)
  {
    try
    {
      var createLeaveTypeCommand = _mapper.Map<CreateLeaveTypeCommand>(leaveType);

      await AddBearerToken();
      await _client.LeaveTypesPOSTAsync(createLeaveTypeCommand);

      return new Response<Guid> { Success = true };
    }
    catch (ApiException ex)
    {
      return ConvertApiExceptions<Guid>(ex);
    }
  }

  public async Task<Response<Guid>> UpdateLeaveType(LeaveTypeViewModel leaveType, int id)
  {
    try
    {
      var updateLeaveCommand = _mapper.Map<UpdateLeaveTypeCommand>(leaveType);

      await AddBearerToken();
      await _client.LeaveTypesPUTAsync(id.ToString(), updateLeaveCommand);

      return new Response<Guid> { Success = true };
    }
    catch (ApiException ex)
    {
      return ConvertApiExceptions<Guid>(ex);
    }
  }

  public async Task<Response<Guid>> DeleteLeaveType(int id)
  {
    try
    {
      await AddBearerToken();
      await _client.LeaveTypesDELETEAsync(id);

      return new Response<Guid> { Success = true };
    }
    catch (ApiException ex)
    {
      return ConvertApiExceptions<Guid>(ex);
    }
  }
}