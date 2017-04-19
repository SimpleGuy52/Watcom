using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Entity.Model;

namespace Entity.Context
{
    public class BusinessContext : DbContext
    {
        public BusinessContext() : base("BusinessContext")
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Kpi> Kpies { get; set; }
        public DbSet<KpiValue> KpiValues { get; set; }
        public DbSet<Page> Pages { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().Property(c => c.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<File>().Property(f => f.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Folder>().Property(f => f.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Kpi>().Property(f => f.Name)
                .HasMaxLength(128)
                .IsRequired();

            modelBuilder.Entity<Page>().Property(f => f.Name)
                .HasMaxLength(128)
                .IsRequired();

            modelBuilder.Entity<Page>().Property(f => f.Value)
                .IsRequired();
        }
    }
}