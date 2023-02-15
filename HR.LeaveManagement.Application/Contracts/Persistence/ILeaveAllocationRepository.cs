using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
{
  Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
  Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId);
  Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
  Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId);
  Task AddAllocations(List<LeaveAllocation> allocations);
  Task<bool> AllocationExists(string userId, int leaveTypeId, int period);
}