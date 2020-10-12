using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HuiNan2020OneClass.Migrations
{
    public partial class Income : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Income",
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
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Income", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Income_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Income_CategoryID",
                table: "Income",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Income");
        }
    }
}
