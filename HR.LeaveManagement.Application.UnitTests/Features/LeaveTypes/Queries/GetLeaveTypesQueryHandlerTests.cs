using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveTypes.Queries;

public class GetLeaveTypesQueryHandlerTests
{
  private readonly IMapper _mapper;
  private readonly Mock<ILeaveTypeRepository> _mockRepo;
  private readonly Mock<IAppLogger<GetLeaveTypesQueryHandler>> _mockAppLogger;

  public GetLeaveTypesQueryHandlerTests()
  {
    var mapperConfig = new MapperConfiguration(c =>
    {
      c.AddProfile<LeaveTypeProfile>();
    });

    _mapper = mapperConfig.CreateMapper();
    _mockRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();
    _mockAppLogger = new Mock<IAppLogger<GetLeaveTypesQueryHandler>>();
  }

  [Fact]
  public async Task GetLeaveTypesTest()
  {
    var handler = new GetLeaveTypesQueryHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);
    var result = await handler.Handle(new GetLeaveTypesQuery(), CancellationToken.None);

    result.ShouldBeOfType<List<LeaveTypeDto>>();
    result.Count.ShouldBe(3);
  }
}