﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HuiNan2020OneClass.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20201030024842_changesqlite")]
    partial class changesqlite
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("HuiNan2020OneClass.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatUserName")
                        .HasColumnType("TEXT");

                    b.Property<int>("IncomOrExp")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsSystem")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("HuiNan2020OneClass.ClassAndStudent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClassAndTermID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatUserName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StudentID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("ClassAndTermID");

                    b.HasIndex("StudentID");

                    b.ToTable("ClassAndStudent");
                });

            modelBuilder.Entity("HuiNan2020OneClass.ClassAndTerm", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClassNuberID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatUserName")
                        .HasColumnType("TEXT");

                    b.Property<int>("GradeID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCurrentClass")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("SchoolTermID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TermNuber")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("ClassNuberID");

                    b.HasIndex("GradeID");

                    b.HasIndex("SchoolTermID");

                    b.ToTable("ClassAndTerm");
                });

            modelBuilder.Entity("HuiNan2020OneClass.ClassIncome", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClassAndTermID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatUserName")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("EveryoneMoney")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Money")
                        .HasColumnType("TEXT");

                    b.Property<string>("Rdmark")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReData")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ClassAndTermID");

                    b.ToTable("ClassIncome");
                });

            modelBuilder.Entity("HuiNan2020OneClass.ClassNuber", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClassNuberName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatUserName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("ClassNuber");
                });

            modelBuilder.Entity("HuiNan2020OneClass.Exp", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatUserName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("JBR")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Money")
                        .HasColumnType("TEXT");

                    b.Property<string>("Rdmark")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReData")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("classAndTermID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("classAndTermID");

                    b.ToTable("Exp");
                });

            modelBuilder.Entity("HuiNan2020OneClass.Grade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("GradeName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("HuiNan2020OneClass.Models.ExpAndIncome.StudentAndIncome", b =>
                {
                    b.Property<int>("ClassIncomeID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ClassIncomeID", "StudentID");

                    b.HasIndex("StudentID");

                    b.ToTable("StudentAndIncome");
                });

            modelBuilder.Entity("HuiNan2020OneClass.OtherIncome", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatUserName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("OtherIncome");
                });

            modelBuilder.Entity("HuiNan2020OneClass.SchoolTerm", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatUserName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("SchoolYear")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SemesterID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("SemesterID");

                    b.ToTable("SchoolTerm");
                });

            modelBuilder.Entity("HuiNan2020OneClass.Semester", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatUserName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SemesterName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Semester");
                });

            modelBuilder.Entity("HuiNan2020OneClass.Sex", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatUserName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SexType")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Sex");
                });

            modelBuilder.Entity("HuiNan2020OneClass.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Borthday")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ClassIncomeID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EnrollmentTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ident")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Pic")
                        .HasColumnType("TEXT");

                    b.Property<string>("QQ")
                        .HasColumnType("TEXT");

                    b.Property<int>("SexID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Weixin")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("ClassIncomeID");

                    b.HasIndex("SexID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("HuiNan2020OneClass.ClassAndStudent", b =>
                {
                    b.HasOne("HuiNan2020OneClass.ClassAndTerm", null)
                        .WithMany("ClassAndStudents")
                        .HasForeignKey("ClassAndTermID");

                    b.HasOne("HuiNan2020OneClass.Student", null)
                        .WithMany("ClassAndStudents")
                        .HasForeignKey("StudentID");
                });

            modelBuilder.Entity("HuiNan2020OneClass.ClassAndTerm", b =>
                {
                    b.HasOne("HuiNan2020OneClass.ClassNuber", "ClassNuber")
                        .WithMany()
                        .HasForeignKey("ClassNuberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HuiNan2020OneClass.Grade", "Grade")
                        .WithMany()
                        .HasForeignKey("GradeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HuiNan2020OneClass.SchoolTerm", "SchoolTerm")
                        .WithMany()
                        .HasForeignKey("SchoolTermID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HuiNan2020OneClass.ClassIncome", b =>
                {
                    b.HasOne("HuiNan2020OneClass.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HuiNan2020OneClass.ClassAndTerm", "classAndTerm")
                        .WithMany()
                        .HasForeignKey("ClassAndTermID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HuiNan2020OneClass.Exp", b =>
                {
                    b.HasOne("HuiNan2020OneClass.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HuiNan2020OneClass.ClassAndTerm", "classAndTerm")
                        .WithMany()
                        .HasForeignKey("classAndTermID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HuiNan2020OneClass.Models.ExpAndIncome.StudentAndIncome", b =>
                {
                    b.HasOne("HuiNan2020OneClass.ClassIncome", "ClassIncome")
                        .WithMany()
                        .HasForeignKey("ClassIncomeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HuiNan2020OneClass.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HuiNan2020OneClass.SchoolTerm", b =>
                {
                    b.HasOne("HuiNan2020OneClass.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HuiNan2020OneClass.Student", b =>
                {
                    b.HasOne("HuiNan2020OneClass.ClassIncome", null)
                        .WithMany("students")
                        .HasForeignKey("ClassIncomeID");

                    b.HasOne("HuiNan2020OneClass.Sex", "Sex")
                        .WithMany()
                        .HasForeignKey("SexID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}