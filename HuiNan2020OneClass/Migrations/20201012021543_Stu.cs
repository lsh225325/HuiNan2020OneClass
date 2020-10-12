using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HuiNan2020OneClass.Migrations
{
    public partial class Stu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    CreatUserName = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    SexID = table.Column<int>(nullable: false),
                    EnrollmentTime = table.Column<DateTime>(nullable: false),
                    GradeClassID = table.Column<int>(nullable: false),
                    Borthday = table.Column<DateTime>(nullable: false),
                    Pic = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Weixin = table.Column<string>(nullable: true),
                    QQ = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Ident = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Student_GradeClass_GradeClassID",
                        column: x => x.GradeClassID,
                        principalTable: "GradeClass",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Sex_SexID",
                        column: x => x.SexID,
                        principalTable: "Sex",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_GradeClassID",
                table: "Student",
                column: "GradeClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_SexID",
                table: "Student",
                column: "SexID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
