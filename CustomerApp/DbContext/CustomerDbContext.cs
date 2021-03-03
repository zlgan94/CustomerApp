using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.DbContext1
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options)
        {
            //initialisation code
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .ToTable("tblCustomer");            
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Product>()
                .ToTable("tblProduct");
            modelBuilder.Entity<Product>()
                .HasKey(c => c.Id);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-UCHNKB4;Initial Catalog=CustomerOrdering;Integrated Security=True");
        //}
        public DbSet<Customer?> Customers {get; set;}
    }
}
