using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace day3.Migrations
{
    public partial class studentUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartment_Course_DepartmentCoursesCrsId",
                table: "CourseDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Course_CrsId",
                table: "StudentCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Students",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "CrsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartment_Courses_DepartmentCoursesCrsId",
                table: "CourseDepartment",
                column: "DepartmentCoursesCrsId",
                principalTable: "Courses",
                principalColumn: "CrsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Courses_CrsId",
                table: "StudentCourses",
                column: "CrsId",
                principalTable: "Courses",
                principalColumn: "CrsId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartment_Courses_DepartmentCoursesCrsId",
                table: "CourseDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Courses_CrsId",
                table: "StudentCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "CrsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartment_Course_DepartmentCoursesCrsId",
                table: "CourseDepartment",
                column: "DepartmentCoursesCrsId",
                principalTable: "Course",
                principalColumn: "CrsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Course_CrsId",
                table: "StudentCourses",
                column: "CrsId",
                principalTable: "Course",
                principalColumn: "CrsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
