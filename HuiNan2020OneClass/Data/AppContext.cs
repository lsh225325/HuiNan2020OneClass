using HuiNan2020OneClass;
using HuiNan2020OneClass.Models.ExpAndIncome;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options)
        : base(options)
    {
    }

    public DbSet<HuiNan2020OneClass.Grade> Grade { get; set; }

    public DbSet<HuiNan2020OneClass.ClassNuber> ClassNuber { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentAndIncome>()
            .HasKey(c => new { c.ClassIncomeID, c.StudentID });
    }

    //重写保存
    public override int SaveChanges()
    {
        SetSystemField();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        SetSystemField();
        return base.SaveChangesAsync();
    }

    private void SetSystemField()
    {
        foreach (var item in ChangeTracker.Entries())
        {
            if (item.Entity is Base)
            {
                Base entity = (Base)item.Entity;
                //添加操作
                if (item.State == EntityState.Added)
                {

                    entity.CreatTime = DateTime.Now;
                    entity.IsDelete = false;
                }
                //修改操作
                // else if (item.State == EntityState.Modified)
                //{
                //    entity.UpdateTime = DateTime.Now;
                //}

            }

        }
    }

    public DbSet<HuiNan2020OneClass.Sex> Sex { get; set; }

    public DbSet<HuiNan2020OneClass.Category> Category { get; set; }

    public DbSet<HuiNan2020OneClass.Exp> Exp { get; set; }

    public DbSet<HuiNan2020OneClass.OtherIncome> OtherIncome { get; set; }

    public DbSet<HuiNan2020OneClass.Student> Student { get; set; }

    public DbSet<HuiNan2020OneClass.SchoolTerm> SchoolTerm { get; set; }

    public DbSet<Semester> Semester { get; set; }

    public DbSet<ClassAndTerm> ClassAndTerm { get; set; }

    public DbSet<StudentAndIncome> StudentAndIncome { get; set; }
    public DbSet<ClassAndStudent> ClassAndStudent { get; set; }
    public DbSet<HuiNan2020OneClass.ClassIncome> ClassIncome { get; set; }



}
