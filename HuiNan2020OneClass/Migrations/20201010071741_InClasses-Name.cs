using Microsoft.EntityFrameworkCore.Migrations;

namespace HuiNan2020OneClass.Migrations
{
    public partial class InClassesName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "GradeClass",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "GradeClass");
        }
    }
}
