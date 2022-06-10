using Microsoft.EntityFrameworkCore;
using PersAccounting.Models;
using PersAccounting.Models.Employees;
using System;

namespace PersAccounting.DB
{
    public class DataBase : IDisposable
    {
        private SQLiteDbContext db;

        public DbSet<Worker> Workers => db.Workers;
        public DbSet<Director> Directors => db.Directors;
        public DbSet<Controller> Controllers => db.Controllers;
        public DbSet<DepartmentHead> DepartmentHeads => db.DepartmentHeads;
        public DbSet<Person> Employees => db.Employees;

        public DataBase()
        {
            db = new SQLiteDbContext();
        }

        public void AddModel<T>(T person) where T : Person
        {
            db.Add(person);
            db.SaveChanges();
        }

        public void EditModel<T>(T person) where T : Person
        {
            db.Update(person);
            db.SaveChanges();
        }

        public void DeleteModel<T>(T person) where T : Person
        {
            db.Remove(person);
            db.SaveChanges();
        }

        public void ClearDataBase()
        {
            db.ClearDB();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
