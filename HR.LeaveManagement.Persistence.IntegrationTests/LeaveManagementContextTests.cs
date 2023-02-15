using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace HR.LeaveManagement.Persistence.IntegrationTests;

public class LeaveManagementContextTests
{
  private readonly LeaveManagementContext _leaveManagementContext;

  public LeaveManagementContextTests()
  {
    var dbOptions = new DbContextOptionsBuilder<LeaveManagementContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

    _leaveManagementContext = new LeaveManagementContext(dbOptions);
  }

  [Fact]
  public async void Save_SetDateCreatedValue()
  {
    // Arrange
    var leaveType = new LeaveType
    {
      Id = 1,
      DefaultDays = 10,
      Name = "Test Vacation"
    };

    // Act
    await _leaveManagementContext.LeaveTypes.AddAsync(leaveType);
    await _leaveManagementContext.SaveChangesAsync();

    // Assert
    leaveType.DateCreated.ShouldNotBeNull();
  }

  [Fact]
  public async void Save_SetDateModifiedValue()
  {
    // Arranage
    var leaveType = new LeaveType
    {
      Id = 1,
      DefaultDays = 10,
      Name = "Test Vacation"
    };

    // Act
    await _leaveManagementContext.LeaveTypes.AddAsync(leaveType);
    await _leaveManagementContext.SaveChangesAsync();

    // Assert
    leaveType.DateModified.ShouldNotBeNull();
  }
}