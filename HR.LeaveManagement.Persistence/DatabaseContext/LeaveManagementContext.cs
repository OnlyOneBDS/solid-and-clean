using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.DatabaseContext;

public class LeaveManagementContext : DbContext
{
  private readonly IUserService _userService;

  public LeaveManagementContext(DbContextOptions<LeaveManagementContext> options, IUserService userService) : base(options)
  {
    _userService = userService;
  }

  public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
  public DbSet<LeaveType> LeaveTypes { get; set; }
  public DbSet<LeaveRequest> LeaveRequests { get; set; }

  public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    foreach (var entry in base.ChangeTracker.Entries<BaseEntity>().Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
    {
      entry.Entity.DateModified = DateTime.Now;
      entry.Entity.ModifiedBy = _userService.UserId;

      if (entry.State == EntityState.Added)
      {
        entry.Entity.DateCreated = DateTime.Now;
        entry.Entity.CreatedBy = _userService.UserId;
      }
    }

    return base.SaveChangesAsync(cancellationToken);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeaveManagementContext).Assembly);
    base.OnModelCreating(modelBuilder);
  }
}