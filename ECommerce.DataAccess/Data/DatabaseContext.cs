using ECommerce.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> option) : base(option)
        {

        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Measurment> Measurments { get; set; }
        public DbSet<MeasurmentType> MeasurmentTypes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stock { get; set; }
        //public DbSet<Stock> StockMain { get; set; }
        //public DbSet<Stock> StockDetail { get; set; }
        public DbSet<Stock_Logs> Stock_Logs { get; set; }
        public DbSet<Stock_Temp> Stock_Temp { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Brand>()
        //        .HasKey(b => b.Id);

        //    modelBuilder.Entity<Category>()
        //        .HasKey(b => b.Id);

        //    modelBuilder.Entity<Measurment>()
        //        .HasKey(b => b.Id);

        //    modelBuilder.Entity<Color>()
        //        .HasKey(b => b.Id);

        //    modelBuilder.Entity<Product>()
        //        .HasMany(p => p.)
        //        .HasOne(p => p.Brand)
        //}

    }
}
