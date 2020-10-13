using Microsoft.EntityFrameworkCore.Migrations;

namespace HuiNan2020OneClass.Migrations
{
    public partial class expaddclassandterm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "classAndTermID",
                table: "Exp",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Exp_classAndTermID",
                table: "Exp",
                column: "classAndTermID");

            migrationBuilder.AddForeignKey(
                name: "FK_Exp_ClassAndTerm_classAndTermID",
                table: "Exp",
                column: "classAndTermID",
                principalTable: "ClassAndTerm",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exp_ClassAndTerm_classAndTermID",
                table: "Exp");

            migrationBuilder.DropIndex(
                name: "IX_Exp_classAndTermID",
                table: "Exp");

            migrationBuilder.DropColumn(
                name: "classAndTermID",
                table: "Exp");
        }
    }
}
