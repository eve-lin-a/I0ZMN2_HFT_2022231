using I0ZMN2_HFT_2021222.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I0ZMN2_HFT_2021222.Repository
{
    public class CarDBContext: DbContext
    {
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<RentCar> Rents { get; set; }

        public CarDBContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=:memory:");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasOne(t => t.CarBrand)
                .WithMany(t => t.Cars)
                .HasForeignKey(t => t.BrandId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<RentCar>(entity =>
            {
                entity.HasOne(t => t.Car)
                .WithMany(t => t.CarRents)
                .HasForeignKey(t => t.CarId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            Brand b1 = new Brand() { Id=1, BrandName="Suzuki", BrandCountry="Japan", BrandYear=1909 };



            Brand b2 = new Brand() { Id = 2, BrandName = "Toyota", BrandCountry = "Japan", BrandYear = 1909 };

            Brand b3 = new Brand() { Id = 3, BrandName = "Ferrari", BrandCountry = "Italy", BrandYear = 1941 };

            Brand b4 = new Brand() { Id = 3, BrandName = "Porsche", BrandCountry = "Germany", BrandYear = 1931 };


        }
    }
}
