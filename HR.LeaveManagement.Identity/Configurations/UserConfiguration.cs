using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Identity.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
  public void Configure(EntityTypeBuilder<ApplicationUser> builder)
  {
    var hasher = new PasswordHasher<ApplicationUser>();

    builder.HasData(
      new ApplicationUser
      {
        Id = "f5b38725-8a13-4e45-8522-ee8882802507",
        Email = "admin@localhost.com",
        NormalizedEmail = "ADMIN@LOCALHOST.COM",
        FirstName = "System",
        LastName = "Admin",
        UserName = "admin@localhost.com",
        NormalizedUserName = "ADMIN@LOCALHOST.COM",
        PasswordHash = hasher.HashPassword(null, "P@ssword1"),
        EmailConfirmed = true
      },
      new ApplicationUser
      {
        Id = "37e36dc2-0ca0-4660-ab32-382c06ef9263",
        Email = "user@localhost.com",
        NormalizedEmail = "USER@LOCALHOST.COM",
        FirstName = "System",
        LastName = "User",
        UserName = "user@localhost.com",
        NormalizedUserName = "USER@LOCALHOST.COM",
        PasswordHash = hasher.HashPassword(null, "P@ssword1"),
        EmailConfirmed = true
      }
    );
  }
}