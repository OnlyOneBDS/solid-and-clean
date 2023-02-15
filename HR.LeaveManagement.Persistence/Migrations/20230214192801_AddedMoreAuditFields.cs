using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.LeaveManagement.Persistence.Migrations;

/// <inheritdoc />
public partial class AddedMoreAuditFields : Migration
{
  /// <inheritdoc />
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.AddColumn<string>(
      name: "CreatedBy",
      table: "LeaveTypes",
      type: "nvarchar(max)",
      nullable: true);

    migrationBuilder.AddColumn<string>(
      name: "ModifiedBy",
      table: "LeaveTypes",
      type: "nvarchar(max)",
      nullable: true);

    migrationBuilder.AddColumn<string>(
      name: "CreatedBy",
      table: "LeaveRequests",
      type: "nvarchar(max)",
      nullable: true);

    migrationBuilder.AddColumn<string>(
      name: "ModifiedBy",
      table: "LeaveRequests",
      type: "nvarchar(max)",
      nullable: true);

    migrationBuilder.AddColumn<string>(
      name: "CreatedBy",
      table: "LeaveAllocations",
      type: "nvarchar(max)",
      nullable: true);

    migrationBuilder.AddColumn<string>(
      name: "ModifiedBy",
      table: "LeaveAllocations",
      type: "nvarchar(max)",
      nullable: true);

    migrationBuilder.UpdateData(
      table: "LeaveTypes",
      keyColumn: "Id",
      keyValue: 1,
      columns: new[] { "CreatedBy", "DateCreated", "DateModified", "ModifiedBy" },
      values: new object[] { null, new DateTime(2023, 2, 14, 14, 28, 1, 563, DateTimeKind.Local).AddTicks(6860), new DateTime(2023, 2, 14, 14, 28, 1, 563, DateTimeKind.Local).AddTicks(6939), null });
  }

  /// <inheritdoc />
  protected override void Down(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.DropColumn(name: "CreatedBy", table: "LeaveTypes");
    migrationBuilder.DropColumn(name: "ModifiedBy", table: "LeaveTypes");
    migrationBuilder.DropColumn(name: "CreatedBy", table: "LeaveRequests");
    migrationBuilder.DropColumn(name: "ModifiedBy", table: "LeaveRequests");
    migrationBuilder.DropColumn(name: "CreatedBy", table: "LeaveAllocations");
    migrationBuilder.DropColumn(name: "ModifiedBy", table: "LeaveAllocations");

    migrationBuilder.UpdateData(
        table: "LeaveTypes",
        keyColumn: "Id",
        keyValue: 1,
        columns: new[] { "DateCreated", "DateModified" },
        values: new object[] { new DateTime(2023, 1, 30, 9, 53, 26, 580, DateTimeKind.Local).AddTicks(8186), new DateTime(2023, 1, 30, 9, 53, 26, 580, DateTimeKind.Local).AddTicks(8241) });
  }
}