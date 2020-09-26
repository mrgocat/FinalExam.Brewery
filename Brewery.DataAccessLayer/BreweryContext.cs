using Brewery.Pocos;
using Microsoft.EntityFrameworkCore;
using System;

namespace Brewery.DataAccessLayer
{
    public class BreweryContext : DbContext
    {
        private const string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BeaweryAPI;Integrated Security=True;";
        public DbSet<BeerPoco> Beers { get; set; }
        public DbSet<BreweryPoco> Brewerys { get; set; }

        /*public BreweryContext(DbContextOptions<BreweryContext> options) : base(options)
        {
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BeerPoco>().HasOne(b => b.Brewery).WithMany(b => b.Beers).HasForeignKey(b => b.BrweryId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
