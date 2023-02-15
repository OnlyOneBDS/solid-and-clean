using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HR.LeaveManagement.Identity.Migrations;

/// <inheritdoc />
public partial class InitialIdentityMigration : Migration
{
  /// <inheritdoc />
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.CreateTable(name: "AspNetRoles", columns: table => new
    {
      Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
      Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
      NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
      ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
    },
    constraints: table =>
    {
      table.PrimaryKey("PK_AspNetRoles", x => x.Id);
    });

    migrationBuilder.CreateTable(name: "AspNetUsers", columns: table => new
    {
      Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
      FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
      LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
      UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
      NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
      Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
      NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
      EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
      PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
      SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
      ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
      PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
      PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
      TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
      LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
      LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
      AccessFailedCount = table.Column<int>(type: "int", nullable: false)
    },
    constraints: table =>
    {
      table.PrimaryKey("PK_AspNetUsers", x => x.Id);
    });

    migrationBuilder.CreateTable(name: "AspNetRoleClaims", columns: table => new
    {
      Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
      RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
      ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
      ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
    },
    constraints: table =>
    {
      table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
      table.ForeignKey(
        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
        column: x => x.RoleId,
        principalTable: "AspNetRoles",
        principalColumn: "Id",
        onDelete: ReferentialAction.Cascade);
    });

    migrationBuilder.CreateTable(name: "AspNetUserClaims", columns: table => new
    {
      Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
      UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
      ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
      ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
    },
    constraints: table =>
    {
      table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
      table.ForeignKey(
        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
        column: x => x.UserId,
        principalTable: "AspNetUsers",
        principalColumn: "Id",
        onDelete: ReferentialAction.Cascade);
    });

    migrationBuilder.CreateTable(name: "AspNetUserLogins", columns: table => new
    {
      LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
      ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
      ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
      UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
    },
    constraints: table =>
    {
      table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
      table.ForeignKey(
        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
        column: x => x.UserId,
        principalTable: "AspNetUsers",
        principalColumn: "Id",
        onDelete: ReferentialAction.Cascade);
    });

    migrationBuilder.CreateTable(name: "AspNetUserRoles", columns: table => new
    {
      UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
      RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
    },
    constraints: table =>
    {
      table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
      table.ForeignKey(
        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
        column: x => x.RoleId,
        principalTable: "AspNetRoles",
        principalColumn: "Id",
        onDelete: ReferentialAction.Cascade);
      table.ForeignKey(
        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
        column: x => x.UserId,
        principalTable: "AspNetUsers",
        principalColumn: "Id",
        onDelete: ReferentialAction.Cascade);
    });

    migrationBuilder.CreateTable(name: "AspNetUserTokens", columns: table => new
    {
      UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
      LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
      Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
      Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
    },
    constraints: table =>
    {
      table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
      table.ForeignKey(
        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
        column: x => x.UserId,
        principalTable: "AspNetUsers",
        principalColumn: "Id",
        onDelete: ReferentialAction.Cascade);
    });

    migrationBuilder.InsertData(
      table: "AspNetRoles",
      columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
      values: new object[,]
      {
        { "1ec29de2-fc03-43e8-9a8d-fcb865c76574", null, "Employee", "EMPLOYEE" },
        { "9423ce23-4725-4a47-80bc-148a3d7f68b2", null, "Administrator", "ADMINISTRATOR" }
      }
    );

    migrationBuilder.InsertData(
      table: "AspNetUsers",
      columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
      values: new object[,]
      {
        { "37e36dc2-0ca0-4660-ab32-382c06ef9263", 0, "aace7f42-db74-49e1-bcf7-934970cfb88a", "user@localhost.com", true, "System", "User", false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEOMrFuSvEvgBdBuF0weUUvV2/a3xsmBQyZ1C/MYQoIP+Du8hvcMhPhMP/HS6nqkE1w==", null, false, "97356118-a205-44ce-96ee-8f5ff1aa196f", false, "user@localhost.com" },
        { "f5b38725-8a13-4e45-8522-ee8882802507", 0, "dd72142e-2954-44c0-80aa-75b0fd3e31b2", "admin@localhost.com", true, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEN4XiapQP9NFSJmV/Ecd0QbcEyEps+XPr/Z1epWBL0jz5MPJsLUQBRQsLgxhFoBXRA==", null, false, "24bdb954-254f-4e40-b7d9-c20547ce6f3f", false, "admin@localhost.com" }
      }
    );

    migrationBuilder.InsertData(
      table: "AspNetUserRoles",
      columns: new[] { "RoleId", "UserId" },
      values: new object[,]
      {
        { "1ec29de2-fc03-43e8-9a8d-fcb865c76574", "37e36dc2-0ca0-4660-ab32-382c06ef9263" },
        { "9423ce23-4725-4a47-80bc-148a3d7f68b2", "f5b38725-8a13-4e45-8522-ee8882802507" }
      });

    migrationBuilder.CreateIndex(
      name: "IX_AspNetRoleClaims_RoleId",
      table: "AspNetRoleClaims",
      column: "RoleId");

    migrationBuilder.CreateIndex(
      name: "RoleNameIndex",
      table: "AspNetRoles",
      column: "NormalizedName",
      unique: true,
      filter: "[NormalizedName] IS NOT NULL");

    migrationBuilder.CreateIndex(
      name: "IX_AspNetUserClaims_UserId",
      table: "AspNetUserClaims",
      column: "UserId");

    migrationBuilder.CreateIndex(
      name: "IX_AspNetUserLogins_UserId",
      table: "AspNetUserLogins",
      column: "UserId");

    migrationBuilder.CreateIndex(
      name: "IX_AspNetUserRoles_RoleId",
      table: "AspNetUserRoles",
      column: "RoleId");

    migrationBuilder.CreateIndex(
      name: "EmailIndex",
      table: "AspNetUsers",
      column: "NormalizedEmail");

    migrationBuilder.CreateIndex(
      name: "UserNameIndex",
      table: "AspNetUsers",
      column: "NormalizedUserName",
      unique: true,
      filter: "[NormalizedUserName] IS NOT NULL");
  }

  /// <inheritdoc />
  protected override void Down(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.DropTable(name: "AspNetRoleClaims");
    migrationBuilder.DropTable(name: "AspNetUserClaims");
    migrationBuilder.DropTable(name: "AspNetUserLogins");
    migrationBuilder.DropTable(name: "AspNetUserRoles");
    migrationBuilder.DropTable(name: "AspNetUserTokens");
    migrationBuilder.DropTable(name: "AspNetRoles");
    migrationBuilder.DropTable(name: "AspNetUsers");
  }
}