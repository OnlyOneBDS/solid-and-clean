using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Identity.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
  public void Configure(EntityTypeBuilder<IdentityRole> builder)
  {
    builder.HasData(
      new IdentityRole
      {
        Id = "1ec29de2-fc03-43e8-9a8d-fcb865c76574",
        Name = "Employee",
        NormalizedName = "EMPLOYEE"
      },
      new IdentityRole
      {
        Id = "9423ce23-4725-4a47-80bc-148a3d7f68b2",
        Name = "Administrator",
        NormalizedName = "ADMINISTRATOR"
      }
    );
  }
}