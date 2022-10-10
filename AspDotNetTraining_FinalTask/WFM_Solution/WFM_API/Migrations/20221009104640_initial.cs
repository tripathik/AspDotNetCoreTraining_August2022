﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WFM_API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employee_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    manager = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    wfm_manager = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lockstatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    profile_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.employee_Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    skillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.skillId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoftLocks",
                columns: table => new
                {
                    lockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_Id = table.Column<int>(type: "int", nullable: false),
                    manager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reqdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastupdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    requestmessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    wfmremark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    managerstatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mgrstatuscomment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mgrlastupdate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftLocks", x => x.lockId);
                    table.ForeignKey(
                        name: "FK_SoftLocks_Employees_employee_Id",
                        column: x => x.employee_Id,
                        principalTable: "Employees",
                        principalColumn: "employee_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillMaps",
                columns: table => new
                {
                    employee_Id = table.Column<int>(type: "int", nullable: false),
                    skillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillMaps", x => new { x.employee_Id, x.skillId });
                    table.ForeignKey(
                        name: "FK_SkillMaps_Employees_employee_Id",
                        column: x => x.employee_Id,
                        principalTable: "Employees",
                        principalColumn: "employee_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillMaps_Skills_skillId",
                        column: x => x.skillId,
                        principalTable: "Skills",
                        principalColumn: "skillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "employee_Id", "email", "Experience", "lockstatus", "manager", "name", "profile_Id", "status", "wfm_manager" },
                values: new object[,]
                {
                    { 1, "bkt123@gmail.com", 2, "Not_Requested", "Rajarajan", "Balkrishna Tripathi", 1, "Active", "Sabitha Balakrishnan" },
                    { 2, "rahulm@gmail.com", 2, "Not_Requested", "Dheeraj Raj", "Rahul Mongia", 1, "Active", "Sabithabalakrishnan" },
                    { 3, "raju@gmail.com", 2, "Requested", "Krishna Tripathi", "Raju Rastogi", 1, "Active", "Raghuraj" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "skillId", "name" },
                values: new object[,]
                {
                    { 1, "C#" },
                    { 2, "Python" },
                    { 3, "React JS" },
                    { 4, "Mongo DB" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillMaps_skillId",
                table: "SkillMaps",
                column: "skillId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftLocks_employee_Id",
                table: "SoftLocks",
                column: "employee_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillMaps");

            migrationBuilder.DropTable(
                name: "SoftLocks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
