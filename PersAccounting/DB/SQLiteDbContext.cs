using Microsoft.EntityFrameworkCore;
using PersAccounting.Models;
using PersAccounting.Models.Employees;
using System;
using System.IO;

namespace PersAccounting.DB
{
    internal class SQLiteDbContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; } = null!;
        public DbSet<Director> Directors { get; set; } = null!;
        public DbSet<Controller> Controllers { get; set; } = null!;
        public DbSet<DepartmentHead> DepartmentHeads { get; set; } = null!;
        public DbSet<Person> Employees { get; set; } = null!;

        private readonly string databaseFolderPath = Directory.GetCurrentDirectory().Replace("\\bin\\Debug\\net6.0-windows", "") + "\\Database";
        private readonly string databaseName = "DB.db";

        public SQLiteDbContext()
        {
            Database.EnsureCreated();
        }

        public void ClearDB()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Directory.Exists(databaseFolderPath) == false)
            {
                Directory.CreateDirectory(databaseFolderPath);
            }
            optionsBuilder.UseSqlite(@$"DataSource={databaseFolderPath}\{databaseName};foreign keys=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>()
               .HasOne(j => j.Head)
               .WithMany()
               .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Controller>()
               .HasOne(j => j.Head)
               .WithMany()
               .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }
    }
}
