using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HuiNan2020OneClass.Migrations
{
    public partial class InClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GradeClass",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    CreatUserName = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    ClassNuberID = table.Column<int>(nullable: false),
                    GradeID = table.Column<int>(nullable: false),
                    EnrollmentYYMM = table.Column<string>(nullable: true),
                    IsCurrentClass = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeClass", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GradeClass_ClassNuber_ClassNuberID",
                        column: x => x.ClassNuberID,
                        principalTable: "ClassNuber",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GradeClass_Grade_GradeID",
                        column: x => x.GradeID,
                        principalTable: "Grade",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GradeClass_ClassNuberID",
                table: "GradeClass",
                column: "ClassNuberID");

            migrationBuilder.CreateIndex(
                name: "IX_GradeClass_GradeID",
                table: "GradeClass",
                column: "GradeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GradeClass");
        }
    }
}
