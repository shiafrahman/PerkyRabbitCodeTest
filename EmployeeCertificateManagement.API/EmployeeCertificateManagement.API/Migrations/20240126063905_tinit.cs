using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeCertificateManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class tinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "Id", "date" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 26, 12, 39, 4, 984, DateTimeKind.Local).AddTicks(1613) },
                    { 2, new DateTime(2024, 1, 25, 12, 39, 4, 984, DateTimeKind.Local).AddTicks(1623) },
                    { 3, new DateTime(2024, 1, 24, 12, 39, 4, 984, DateTimeKind.Local).AddTicks(1629) },
                    { 4, new DateTime(2024, 1, 23, 12, 39, 4, 984, DateTimeKind.Local).AddTicks(1630) },
                    { 5, new DateTime(2024, 1, 22, 12, 39, 4, 984, DateTimeKind.Local).AddTicks(1631) }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DeptName" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "HR" },
                    { 3, "Finance" },
                    { 4, "Marketing" },
                    { 5, "Operations" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CertificateId", "DeptId", "EmpName", "Salary" },
                values: new object[,]
                {
                    { 1, 1, 1, "John Doe", 50000m },
                    { 2, 2, 2, "Jane Doe", 60000m },
                    { 3, 3, 3, "Bob Smith", 70000m },
                    { 4, 4, 4, "Alice Johnson", 55000m },
                    { 5, 5, 5, "Charlie Brown", 80000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
