using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Identity.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
  public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
  {
    builder.HasData(
      new IdentityUserRole<string>
      {
        RoleId = "9423ce23-4725-4a47-80bc-148a3d7f68b2",
        UserId = "f5b38725-8a13-4e45-8522-ee8882802507"
      },
      new IdentityUserRole<string>
      {
        RoleId = "1ec29de2-fc03-43e8-9a8d-fcb865c76574",
        UserId = "37e36dc2-0ca0-4660-ab32-382c06ef9263"
      }
    );
  }
}