using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace HuiNan2020OneClass.Migrations
{
    public partial class changesqlite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    CreatUserName = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CategoryName = table.Column<string>(nullable: false),
                    IncomOrExp = table.Column<int>(nullable: false),
                    IsSystem = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClassNuber",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    CreatUserName = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    ClassNuberName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassNuber", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    CreatUserName = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    GradeName = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OtherIncome",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    CreatUserName = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherIncome", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    CreatUserName = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    SemesterName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sex",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                name: "SchoolTerm",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    CreatUserName = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    SchoolYear = table.Column<int>(nullable: false),
                    SemesterID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolTerm", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SchoolTerm_Semester_SemesterID",
                        column: x => x.SemesterID,
                        principalTable: "Semester",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassAndTerm",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    CreatUserName = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    ClassNuberID = table.Column<int>(nullable: false),
                    GradeID = table.Column<int>(nullable: false),
                    SchoolTermID = table.Column<int>(nullable: false),
                    TermNuber = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsCurrentClass = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassAndTerm", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClassAndTerm_ClassNuber_ClassNuberID",
                        column: x => x.ClassNuberID,
                        principalTable: "ClassNuber",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassAndTerm_Grade_GradeID",
                        column: x => x.GradeID,
                        principalTable: "Grade",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassAndTerm_SchoolTerm_SchoolTermID",
                        column: x => x.SchoolTermID,
                        principalTable: "SchoolTerm",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassIncome",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    CreatUserName = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    ClassAndTermID = table.Column<int>(nullable: false),
                    ReData = table.Column<DateTime>(nullable: false),
                    Rdmark = table.Column<string>(nullable: false),
                    EveryoneMoney = table.Column<decimal>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    Money = table.Column<decimal>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassIncome", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClassIncome_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassIncome_ClassAndTerm_ClassAndTermID",
                        column: x => x.ClassAndTermID,
                        principalTable: "ClassAndTerm",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exp",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    CreatUserName = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    classAndTermID = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Exp_ClassAndTerm_classAndTermID",
                        column: x => x.classAndTermID,
                        principalTable: "ClassAndTerm",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    CreatUserName = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    SexID = table.Column<int>(nullable: false),
                    EnrollmentTime = table.Column<DateTime>(nullable: false),
                    Borthday = table.Column<DateTime>(nullable: false),
                    Pic = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Weixin = table.Column<string>(nullable: true),
                    QQ = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Ident = table.Column<string>(nullable: true),
                    ClassIncomeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Student_ClassIncome_ClassIncomeID",
                        column: x => x.ClassIncomeID,
                        principalTable: "ClassIncome",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Sex_SexID",
                        column: x => x.SexID,
                        principalTable: "Sex",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassAndStudent",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    CreatUserName = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    ClassAndTermID = table.Column<int>(nullable: true),
                    StudentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassAndStudent", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClassAndStudent_ClassAndTerm_ClassAndTermID",
                        column: x => x.ClassAndTermID,
                        principalTable: "ClassAndTerm",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassAndStudent_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentAndIncome",
                columns: table => new
                {
                    StudentID = table.Column<int>(nullable: false),
                    ClassIncomeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAndIncome", x => new { x.ClassIncomeID, x.StudentID });
                    table.ForeignKey(
                        name: "FK_StudentAndIncome_ClassIncome_ClassIncomeID",
                        column: x => x.ClassIncomeID,
                        principalTable: "ClassIncome",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAndIncome_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassAndStudent_ClassAndTermID",
                table: "ClassAndStudent",
                column: "ClassAndTermID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAndStudent_StudentID",
                table: "ClassAndStudent",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAndTerm_ClassNuberID",
                table: "ClassAndTerm",
                column: "ClassNuberID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAndTerm_GradeID",
                table: "ClassAndTerm",
                column: "GradeID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAndTerm_SchoolTermID",
                table: "ClassAndTerm",
                column: "SchoolTermID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassIncome_CategoryID",
                table: "ClassIncome",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassIncome_ClassAndTermID",
                table: "ClassIncome",
                column: "ClassAndTermID");

            migrationBuilder.CreateIndex(
                name: "IX_Exp_CategoryID",
                table: "Exp",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Exp_classAndTermID",
                table: "Exp",
                column: "classAndTermID");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolTerm_SemesterID",
                table: "SchoolTerm",
                column: "SemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ClassIncomeID",
                table: "Student",
                column: "ClassIncomeID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_SexID",
                table: "Student",
                column: "SexID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAndIncome_StudentID",
                table: "StudentAndIncome",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassAndStudent");

            migrationBuilder.DropTable(
                name: "Exp");

            migrationBuilder.DropTable(
                name: "OtherIncome");

            migrationBuilder.DropTable(
                name: "StudentAndIncome");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "ClassIncome");

            migrationBuilder.DropTable(
                name: "Sex");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "ClassAndTerm");

            migrationBuilder.DropTable(
                name: "ClassNuber");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "SchoolTerm");

            migrationBuilder.DropTable(
                name: "Semester");
        }
    }
}
