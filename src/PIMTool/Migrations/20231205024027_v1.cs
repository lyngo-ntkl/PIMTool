using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIMTool.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Projects",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.DropPrimaryKey(
                "PK_Projects",
                "Projects");


            migrationBuilder.AlterColumn<decimal>(
                name: "Id",
                table: "Projects",
                type: "numeric(19, 0)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
            migrationBuilder.AddPrimaryKey(
                "PK_Projects",
                "Projects",
                "Id");

            migrationBuilder.AddColumn<string>(
                name: "Customer",
                table: "Projects",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Projects",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GroupId",
                table: "Projects",
                type: "numeric(19,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ProjectNumber",
                table: "Projects",
                type: "numeric(4,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Projects",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Projects",
                type: "char(3)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Version",
                table: "Projects",
                type: "numeric(10,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "numeric(19, 0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Visa = table.Column<string>(type: "char(3)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    Version = table.Column<decimal>(type: "numeric(10,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "numeric(19, 0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupLeaderId = table.Column<decimal>(type: "numeric(19,0)", nullable: false),
                    Version = table.Column<decimal>(type: "numeric(10,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Employees_GroupLeaderId",
                        column: x => x.GroupLeaderId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectEmployees",
                columns: table => new
                {
                    ProjectId = table.Column<decimal>(type: "numeric(19,0)", nullable: false),
                    EmployeeId = table.Column<decimal>(type: "numeric(19,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEmployees", x => new { x.ProjectId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_ProjectEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectEmployees_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_GroupId",
                table: "Projects",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_GroupLeaderId",
                table: "Groups",
                column: "GroupLeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployees_EmployeeId",
                table: "ProjectEmployees",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Groups_GroupId",
                table: "Projects",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Groups_GroupId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "ProjectEmployees");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Projects_GroupId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Customer",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectNumber",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Projects");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Projects",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");
        }
    }
}
