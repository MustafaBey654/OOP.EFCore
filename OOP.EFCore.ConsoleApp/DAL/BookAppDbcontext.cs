using Microsoft.EntityFrameworkCore;
using OOP.EFCore.ConsoleApp.DAL.Mapping;
using OOP.EFCore.ConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.EFCore.ConsoleApp.DAL
{
    public class BookAppDbcontext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source  = (localdb)\\MSSQLLocalDB;Initial Catalog = BookAppDb;");
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Book Map üzerindeki kuralları uygulayarak magration yap. 
            modelBuilder.ApplyConfiguration(new BookMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
        }
    }
}
