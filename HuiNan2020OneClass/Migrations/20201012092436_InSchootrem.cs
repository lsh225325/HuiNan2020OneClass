using Microsoft.EntityFrameworkCore.Migrations;

namespace HuiNan2020OneClass.Migrations
{
    public partial class InSchootrem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolTerm_Semester_SemesterID",
                table: "SchoolTerm");

            migrationBuilder.AlterColumn<int>(
                name: "SemesterID",
                table: "SchoolTerm",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SchoolTerm",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolTerm_Semester_SemesterID",
                table: "SchoolTerm",
                column: "SemesterID",
                principalTable: "Semester",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolTerm_Semester_SemesterID",
                table: "SchoolTerm");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SchoolTerm");

            migrationBuilder.AlterColumn<int>(
                name: "SemesterID",
                table: "SchoolTerm",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolTerm_Semester_SemesterID",
                table: "SchoolTerm",
                column: "SemesterID",
                principalTable: "Semester",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
