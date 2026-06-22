using Microsoft.EntityFrameworkCore;
using System;
using PaliwoSpotter;

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
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PaliwoSpotterDB;Integrated Security=True",
                x => x.UseNetTopologySuite());
        }
    }
}
