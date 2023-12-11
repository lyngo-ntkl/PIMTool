using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIMTool.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName", "Version", "Visa" },
                values: new object[,]
                {
                    { 1m, new DateTime(2002, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ly", "Ngô", 0m, "VN" },
                    { 2m, new DateTime(2002, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Linh", "Nguyễn", 0m, "VN" },
                    { 3m, new DateTime(1994, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lan", "Trần", 0m, "VN" },
                    { 4m, new DateTime(1996, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Duy", "Hoàng", 0m, "VN" },
                    { 5m, new DateTime(1997, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Huy", "Phan", 0m, "VN" },
                    { 6m, new DateTime(2000, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Minh", "Doãn", 0m, "VN" },
                    { 7m, new DateTime(2001, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quang", "Tô", 0m, "VN" },
                    { 8m, new DateTime(1999, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trường", "Phạm", 0m, "VN" },
                    { 9m, new DateTime(1998, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tiến", "Vũ", 0m, "VN" },
                    { 10m, new DateTime(2004, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thịnh", "Đinh", 0m, "VN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1m);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2m);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3m);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4m);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5m);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6m);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7m);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8m);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9m);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10m);
        }
    }
}
