using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmployees.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "312 Forest Avenue, BF 923", "USA", "Admin_Solutions Ltd" },
                    { new Guid("73625b4e-4149-4912-b6d9-08a595d78124"), "50 street, YemenSoft building", "Yemen", "YemenSoft" },
                    { new Guid("a627d731-5382-4bf4-87c0-4f256fddd004"), "Marib street, Al-akwa3 building", "Yemen", "Ebda3Soft" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "583 Wall Dr. Gwynn Oak, MD 21207", "USA", "IT_Solutions Ltd" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "CompanyId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("50c1aed5-a50a-4f64-9533-910e68c30206"), 35, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Kane Miller", "Administrator" },
                    { new Guid("617f7f3f-1188-47c8-9ecc-df285c605fa0"), 24, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Mohammed Al-Batool", "Mobile Developer" },
                    { new Guid("6adcb64f-178f-4a37-bc3a-0261972d9375"), 24, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Osamah Al-Obary", "Software Developer" },
                    { new Guid("7cce86d2-ee60-4de9-a098-ab8e45cce73a"), 26, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Sam Raiden", "Software developer" },
                    { new Guid("a4ff3237-13c3-4ee1-9f8b-57d2e38b997a"), 32, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Osamah Salam", "Customer Service" },
                    { new Guid("ae6dff3c-abf4-4d79-a74e-3e14648db2f5"), 30, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Jana McLeaf", "Software developer" },
                    { new Guid("babb5dff-d056-4620-a14c-4acc2f421af6"), 26, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Ahmed Al-Hemuary", "Tester" },
                    { new Guid("bc1f78cf-c7e3-4e78-b5d9-f4a1a3a1ddce"), 30, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Khaled Ali", "Sofrware Developer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
