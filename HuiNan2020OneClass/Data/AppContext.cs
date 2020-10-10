using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HuiNan2020OneClass;

    public class AppContext : DbContext
    {
        public AppContext (DbContextOptions<AppContext> options)
            : base(options)
        {
        }

        public DbSet<HuiNan2020OneClass.Grade> Grade { get; set; }

        public DbSet<HuiNan2020OneClass.ClassNuber> ClassNuber { get; set; }
    }
