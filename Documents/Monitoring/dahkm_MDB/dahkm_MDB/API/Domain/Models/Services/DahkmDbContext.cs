using dahkm_MDB.API.Domain.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dahkm_MDB.API.Domain.Models.Services
{
    public class DahkmDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public DahkmDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Metrics> Metrics { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Metrics
            builder.Entity<Metrics>().ToTable("Metrics");
            builder.Entity<Metrics>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Metrics>().Property(p => p.Date).IsRequired();
            builder.Entity<Metrics>().Property(p => p.ClicksAM);
            builder.Entity<Metrics>().Property(p => p.ClicksAfternoon);
            builder.Entity<Metrics>().Property(p => p.ClicksPM);
            builder.Entity<Metrics>().Property(p => p.ConversionRate);

            //Customer
            builder.Entity<Customer>().ToTable("Customers"); 
            builder.Entity<Customer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Customer>().HasMany<Order>(c => c.Orders).WithOne(o => o.Customer);
            builder.Entity<Customer>().Property(p => p.PhoneNumber);
            builder.Entity<Customer>().Property(p => p.FirstName);
            builder.Entity<Customer>().Property(p => p.LastName);
            builder.Entity<Customer>().Property(p => p.Address);
            builder.Entity<Customer>().Property(p => p.BalanceDue);
            builder.Entity<Customer>().Property(p => p.CityId);
            builder.Entity<Customer>().Property(p => p.ZipCode);

            //Manufacturer
            builder.Entity<Manufacturer>().ToTable("Manufacturers");
            builder.Entity<Manufacturer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Manufacturer>().Property(p => p.PhoneNumber);
            builder.Entity<Manufacturer>().Property(p => p.Name);
            builder.Entity<Manufacturer>().Property(p => p.StreetAddress);
            builder.Entity<Manufacturer>().Property(p => p.ZipCode);
            builder.Entity<Manufacturer>().Property(p => p.City);
            builder.Entity<Manufacturer>().HasMany<Product>(m => m.Products).WithOne(p => p.Manufacturer);

            //Order
            builder.Entity<Order>().ToTable("Orders");
            builder.Entity<Order>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Order>().Property(p => p.OrderDate);
            builder.Entity<Order>().Property(p => p.RecieveDate);
            builder.Entity<Order>().Property(p => p.AmountDue);
            builder.Entity<Order>().Property(p => p.Discount);
            builder.Entity<Order>().Property(p => p.Quantity);
            builder.Entity<Order>().HasOne<Product>(o => o.Product).WithMany(p => p.Orders).HasForeignKey(o => o.ProductId);
            builder.Entity<Order>().HasOne<Customer>(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId);

            //Product
            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().HasMany<Order>(p => p.Orders).WithOne(o => o.Product);
            builder.Entity<Product>().HasOne<Manufacturer>(p => p.Manufacturer).WithMany(m => m.Products).HasForeignKey(p => p.ManufacturerId);
            builder.Entity<Product>().Property(p => p.ModelNumber);
            builder.Entity<Product>().Property(p => p.Name);
            builder.Entity<Product>().Property(p => p.PricePerUnit);
            builder.Entity<Product>().Property(p => p.Type);

            //Vendor
            builder.Entity<Vendor>().ToTable("Vendors");
            builder.Entity<Vendor>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Vendor>().HasMany<Product>(v => v.Products);
            builder.Entity<Vendor>().Property(p => p.StreetAddress);
            builder.Entity<Vendor>().Property(p => p.PhoneNumber);
            builder.Entity<Vendor>().Property(p => p.Name);
            builder.Entity<Vendor>().Property(p => p.ZipCode);
            builder.Entity<Vendor>().Property(p => p.City);
  

            builder.Entity<Metrics>().HasData
            (
                new Metrics { Id = 39253928, Date = new DateTime(2019, 12, 4), ClicksAM = 5, ClicksAfternoon = 10, ClicksPM = 13, ConversionRate = 2.2m } 
                
            );
        }
    }
}
