using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmployees.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedEmployeeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "CompanyId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("50c1aed5-a50a-4f64-9533-910e68c30206"), 35, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Kane Miller", "Adminstrater" },
                    { new Guid("7cce86d2-ee60-4de9-a098-ab8e45cce73a"), 26, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Sam Raiden", "Accounting" },
                    { new Guid("a4ff3237-13c3-4ee1-9f8b-57d2e38b997a"), 32, new Guid("73625b4e-4149-4912-b6d9-08a595d78124"), "Osamah Salam", "Customer service" },
                    { new Guid("ae6dff3c-abf4-4d79-a74e-3e14648db2f5"), 30, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Jana McLeaf", "Marketing " },
                    { new Guid("b222cc38-2ecb-4314-88e9-2c8a7ce4a554"), 24, new Guid("a627d731-5382-4bf4-87c0-4f256fddd004"), "Mohammed Al-Batool", "Mobile developer" },
                    { new Guid("babb5dff-d056-4620-a14c-4acc2f421af6"), 26, new Guid("a627d731-5382-4bf4-87c0-4f256fddd004"), "Ahmed Al-Hemuary", "Tester" },
                    { new Guid("fc61c65c-1861-4d0d-b091-8c85a2c21171"), 24, new Guid("a627d731-5382-4bf4-87c0-4f256fddd004"), "Osamah Al-Obary", "Software developer" },
                    { new Guid("ffa02d9a-37d9-4565-9f2f-bfd079666116"), 30, new Guid("a627d731-5382-4bf4-87c0-4f256fddd004"), "Khaled Ali", "Software developer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("50c1aed5-a50a-4f64-9533-910e68c30206"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("7cce86d2-ee60-4de9-a098-ab8e45cce73a"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a4ff3237-13c3-4ee1-9f8b-57d2e38b997a"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("ae6dff3c-abf4-4d79-a74e-3e14648db2f5"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("b222cc38-2ecb-4314-88e9-2c8a7ce4a554"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("babb5dff-d056-4620-a14c-4acc2f421af6"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("fc61c65c-1861-4d0d-b091-8c85a2c21171"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("ffa02d9a-37d9-4565-9f2f-bfd079666116"));
        }
    }
}
