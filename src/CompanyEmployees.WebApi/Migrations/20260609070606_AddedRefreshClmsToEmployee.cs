using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyEmployees.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedRefreshClmsToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiresAt",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshTokenHash",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenRevokedAt",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("50c1aed5-a50a-4f64-9533-910e68c30206"),
                columns: new[] { "RefreshTokenExpiresAt", "RefreshTokenHash", "RefreshTokenRevokedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("7cce86d2-ee60-4de9-a098-ab8e45cce73a"),
                columns: new[] { "RefreshTokenExpiresAt", "RefreshTokenHash", "RefreshTokenRevokedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a4ff3237-13c3-4ee1-9f8b-57d2e38b997a"),
                columns: new[] { "RefreshTokenExpiresAt", "RefreshTokenHash", "RefreshTokenRevokedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("ae6dff3c-abf4-4d79-a74e-3e14648db2f5"),
                columns: new[] { "RefreshTokenExpiresAt", "RefreshTokenHash", "RefreshTokenRevokedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("b222cc38-2ecb-4314-88e9-2c8a7ce4a554"),
                columns: new[] { "RefreshTokenExpiresAt", "RefreshTokenHash", "RefreshTokenRevokedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("babb5dff-d056-4620-a14c-4acc2f421af6"),
                columns: new[] { "RefreshTokenExpiresAt", "RefreshTokenHash", "RefreshTokenRevokedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("fc61c65c-1861-4d0d-b091-8c85a2c21171"),
                columns: new[] { "RefreshTokenExpiresAt", "RefreshTokenHash", "RefreshTokenRevokedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("ffa02d9a-37d9-4565-9f2f-bfd079666116"),
                columns: new[] { "RefreshTokenExpiresAt", "RefreshTokenHash", "RefreshTokenRevokedAt" },
                values: new object[] { null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiresAt",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "RefreshTokenHash",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "RefreshTokenRevokedAt",
                table: "Employees");
        }
    }
}
