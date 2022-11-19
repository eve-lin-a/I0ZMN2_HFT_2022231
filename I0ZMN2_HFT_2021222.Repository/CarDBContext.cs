﻿using I0ZMN2_HFT_2021222.Models;
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

            Brand brand1 = new Brand() { Id=1, BrandName="Suzuki", BrandCountry="Japan", BrandYear=1909 };
            //new or used bool rolstringre irva
            Car car1=new Car() { Id = 1, CarName = "Suzuki Car1", CarType = "Swift", CarPrice = 1, NewOrUsed = "new", CarReleaseYear = 2000, 
                CarColor = "black", CarSeatNumber = 4, IsLeftWheel = true, FuelType = "diesel", IsElectricCar = true };

            Car car2 = new Car()
            {
                Id = 2,
                CarName = "Suzuki Car2",
                CarType = "Swift",
                CarPrice = 3,
                NewOrUsed = "new",
                CarReleaseYear = 2005,
                CarColor = "white",
                CarSeatNumber = 4,
                IsLeftWheel = false,
                FuelType = "gasoline",
                IsElectricCar = true
            };

            Car car3 = new Car()
            {
                Id = 3,
                CarName = "Suzuki Car3",
                CarType = "Ignis",
                CarPrice = 15,
                NewOrUsed = "used",
                CarReleaseYear = 2020,
                CarColor = "red",
                CarSeatNumber = 6,
                IsLeftWheel = false,
                FuelType = "gasoline",
                IsElectricCar = false
            };

            Car car4 = new Car()
            {
                Id = 4,
                CarName = "Suzuki Car4",
                CarType = "Vitara",
                CarPrice = 1,
                NewOrUsed = "used",
                CarReleaseYear = 1990,
                CarColor = "green",
                CarSeatNumber = 4,
                IsLeftWheel = false,
                FuelType = "diesel",
                IsElectricCar = false
            };

            RentCar rentcar1 = new RentCar() { RentId = 1, BuyerName = "Sanya", BuyDate = 2020, BuyerGender = "male", IsFirstCar = false };
            RentCar rentcar2 = new RentCar() { RentId = 2, BuyerName = "Viktor", BuyDate = 2022, BuyerGender = "male", IsFirstCar = true };
            RentCar rentcar3 = new RentCar() { RentId = 3, BuyerName = "Evelin", BuyDate = 2022, BuyerGender = "female", IsFirstCar = true };
            RentCar rentcar4 = new RentCar() { RentId = 4, BuyerName = "Erzsi", BuyDate = 2018, BuyerGender = "female", IsFirstCar = false };




            Brand brand2 = new Brand() { Id = 2, BrandName = "Toyota", BrandCountry = "Japan", BrandYear = 1909 };

            Car car1b2 = new Car()
            {
                Id = 5,
                CarName = "Toyota Car1",
                CarType = "Yaris",
                CarPrice = 4,
                NewOrUsed = "new",
                CarReleaseYear = 2020,
                CarColor = "red",
                CarSeatNumber = 4,
                IsLeftWheel = false,
                FuelType = "gasoline",
                IsElectricCar = true
            };
            Car car2b2 = new Car()
            {
                Id = 6,
                CarName = "Toyota Car2",
                CarType = "Corolla",
                CarPrice = 1,
                NewOrUsed = "used",
                CarReleaseYear = 2000,
                CarColor = "green",
                CarSeatNumber = 3,
                IsLeftWheel = true,
                FuelType = "diesel",
                IsElectricCar = false
            };
            Car car3b2 = new Car()
            {
                Id = 7,
                CarName = "Toyota Car3",
                CarType = "Yaris",
                CarPrice = 2,
                NewOrUsed = "new",
                CarReleaseYear = 2010,
                CarColor = "white",
                CarSeatNumber = 4,
                IsLeftWheel = true,
                FuelType = "diesel",
                IsElectricCar = false
            };
            Car car4b2 = new Car()
            {
                Id = 8,
                CarName = "Toyota Car4",
                CarType = "Sienna",
                CarPrice = 10,
                NewOrUsed = "new",
                CarReleaseYear = 2017,
                CarColor = "black",
                CarSeatNumber = 4,
                IsLeftWheel = true,
                FuelType = "gasoline",
                IsElectricCar = true
            };

            Brand brand3 = new Brand() { Id = 3, BrandName = "Ferrari", BrandCountry = "Italy", BrandYear = 1941 };
            Car car1b3 = new Car()
            {
                Id = 9,
                CarName = "Ferrari Car1",
                CarType = "Ferrari 488",
                CarPrice = 10,
                NewOrUsed = "new",
                CarReleaseYear = 2011,
                CarColor = "black",
                CarSeatNumber = 6,
                IsLeftWheel = true,
                FuelType = "gasoline",
                IsElectricCar = true
            };
            Car car2b3 = new Car()
            {
                Id = 10,
                CarName = "Ferrari Car2",
                CarType = "Ferrari 488",
                CarPrice = 15,
                NewOrUsed = "used",
                CarReleaseYear = 2018,
                CarColor = "red",
                CarSeatNumber = 4,
                IsLeftWheel = true,
                FuelType = "diesel",
                IsElectricCar = false
            };
            Car car3b3 = new Car()
            {
                Id = 11,
                CarName = "Ferrari Car3",
                CarType = "Ferrari 458 Italia",
                CarPrice = 20,
                NewOrUsed = "new",
                CarReleaseYear = 2015,
                CarColor = "white",
                CarSeatNumber = 4,
                IsLeftWheel = true,
                FuelType = "gasoline",
                IsElectricCar = false
            };
            Car car4b3 = new Car()
            {
                Id = 12,
                CarName = "Ferrari Car4",
                CarType = "Ferrari Portofino",
                CarPrice = 22,
                NewOrUsed = "new",
                CarReleaseYear = 2020,
                CarColor = "black",
                CarSeatNumber = 4,
                IsLeftWheel = false,
                FuelType = "gasoline",
                IsElectricCar = true
            };

            Brand brand4 = new Brand() { Id = 3, BrandName = "Porsche", BrandCountry = "Germany", BrandYear = 1931 };
            Car car1b4 = new Car()
            {
                Id = 13,
                CarName = "Porsche Car1",
                CarType = "Porsche 911",
                CarPrice = 10,
                NewOrUsed = "new",
                CarReleaseYear = 2017,
                CarColor = "black",
                CarSeatNumber = 4,
                IsLeftWheel = true,
                FuelType = "gasoline",
                IsElectricCar = true
            };
            Car car2b4 = new Car()
            {
                Id = 14,
                CarName = "Porsche Car2",
                CarType = "Porsche 968 Turbo S",
                CarPrice = 100,
                NewOrUsed = "new",
                CarReleaseYear = 2016,
                CarColor = "white",
                CarSeatNumber = 4,
                IsLeftWheel = false,
                FuelType = "gasoline",
                IsElectricCar = true
            };
            Car car3b4 = new Car()
            {
                Id = 15,
                CarName = "Porsche Car3",
                CarType = "Porsche 999",
                CarPrice = 40,
                NewOrUsed = "used",
                CarReleaseYear = 2005,
                CarColor = "black",
                CarSeatNumber = 6,
                IsLeftWheel = true,
                FuelType = "diesel",
                IsElectricCar = false
            };
            Car car4b4 = new Car()
            {
                Id = 16,
                CarName = "Porsche Car4",
                CarType = "Porsche 999",
                CarPrice = 35,
                NewOrUsed = "new",
                CarReleaseYear = 2019,
                CarColor = "red",
                CarSeatNumber = 4,
                IsLeftWheel = true,
                FuelType = "gasoline",
                IsElectricCar = true
            };


        }
    }
}
