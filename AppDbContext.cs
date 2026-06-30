using Microsoft.EntityFrameworkCore;
using System;
using PaliwoSpotter;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Text;

namespace PaliwoSpotter
{
    internal class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Brand> Brands { get; set; } 
        public DbSet<Station> Stations { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<PriceReport> PriceReports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                string? connectionString = configuration.GetConnectionString("DefaultConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }


         
        }
    }
}
