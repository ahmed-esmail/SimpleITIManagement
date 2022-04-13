﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace day3.Migrations
{
    public partial class DepartmentCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseDepartment",
                columns: table => new
                {
                    CourseDepartmentsDeptId = table.Column<int>(type: "int", nullable: false),
                    DepartmentCoursesCrsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDepartment", x => new { x.CourseDepartmentsDeptId, x.DepartmentCoursesCrsId });
                    table.ForeignKey(
                        name: "FK_CourseDepartment_Course_DepartmentCoursesCrsId",
                        column: x => x.DepartmentCoursesCrsId,
                        principalTable: "Course",
                        principalColumn: "CrsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseDepartment_Departments_CourseDepartmentsDeptId",
                        column: x => x.CourseDepartmentsDeptId,
                        principalTable: "Departments",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseDepartment_DepartmentCoursesCrsId",
                table: "CourseDepartment",
                column: "DepartmentCoursesCrsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseDepartment");
        }
    }
}
