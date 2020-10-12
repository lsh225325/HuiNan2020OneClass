using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HuiNan2020OneClass.Migrations
{
    public partial class InCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    CreatUserName = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CategoryName = table.Column<string>(nullable: false),
                    IncomOrExp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sex",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    CreatUserName = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    SexType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sex", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Exp",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    CreatUserName = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    ReData = table.Column<DateTime>(nullable: false),
                    Rdmark = table.Column<string>(nullable: false),
                    Money = table.Column<decimal>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    JBR = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exp", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Exp_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exp_CategoryID",
                table: "Exp",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exp");

            migrationBuilder.DropTable(
                name: "Sex");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
