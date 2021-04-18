using System;
using Entities.Concrete;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class CarRentalContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //NpgsqlConnection connection = new NpgsqlConnection("server=localHost; port=5432; Database=ReCap; User Id=postgres; Password=123456");

            optionsBuilder.UseNpgsql("server=localHost; port=5432; Database=ReCap; User Id=postgres; Password=123456");

            //optionsBuilder.UseSqlServer(@"server=localHost; port=5432; Database=ReCap; User Id=postgres; Password=123456");

            //optionsBuilder.UseSqlServer("server=localHost; Database=ReCap; User Id=postgres; Password=123456");
        }    

        //NpgsqlConnection connection = new NpgsqlConnection("server=localHost; port=5432; Database=ReCap; User Id=postgres; Password=123456");


        public DbSet<Car> Cars { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Rental> Rentals { get; set; }

        public DbSet<CarImage> CarImages { get; set; }

    }
}
