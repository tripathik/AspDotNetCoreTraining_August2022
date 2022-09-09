using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WfmDataContext.Migrations
{
    public partial class initm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Employee_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Manager = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Wfm_manager = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lockstatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Experience = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Profile_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Employee_id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Skillid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Skillid);
                });

            migrationBuilder.CreateTable(
                name: "Softlock",
                columns: table => new
                {
                    LockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_id = table.Column<int>(type: "int", nullable: false),
                    Manager = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ReqDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Lastupdated = table.Column<DateTime>(type: "datetime", nullable: false),
                    RequestMessage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WfmRemark = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ManagerStatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MgrStatusComment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MgrLastUpdate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Softlock", x => x.LockId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Skillmap",
                columns: table => new
                {
                    Skillid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Employee_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_EmployeeId",
                        column: x => x.Employee_id,
                        principalTable: "Employees",
                        principalColumn: "Employee_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillId",
                        column: x => x.Skillid,
                        principalTable: "Skills",
                        principalColumn: "Skillid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skillmap_Employee_id",
                table: "Skillmap",
                column: "Employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Skillmap_Skillid",
                table: "Skillmap",
                column: "Skillid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skillmap");

            migrationBuilder.DropTable(
                name: "Softlock");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
