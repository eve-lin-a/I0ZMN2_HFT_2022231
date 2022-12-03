using I0ZMN2_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I0ZMN2_HFT_2022231.Repository
{
    public class CarDBContext: DbContext
    {
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<RentCar> RentCars { get; set; }

        public CarDBContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {

                builder.UseLazyLoadingProxies();
                builder.UseInMemoryDatabase("Car");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasOne(Car => Car.Brand)
                    .WithMany(Brand => Brand.Cars)
                    .HasForeignKey(Car => Car.Brand_id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<RentCar>(entity =>
            {
                entity.HasOne(RentCar => RentCar.Car)
                    .WithMany(Car => Car.RentCars)
                    .HasForeignKey(RentCar => RentCar.Car_id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            Brand Brand1 = new Brand() { Id = 1, BrandName = "Suzuki", BrandCountry = "Japan", BrandYear = 1909 };
            Brand Brand2 = new Brand() { Id = 2, BrandName = "Toyota", BrandCountry = "Japan", BrandYear = 1909 };
            Brand Brand3 = new Brand() { Id = 3, BrandName = "Ferrari", BrandCountry = "Italy", BrandYear = 1941 };
            Brand Brand4 = new Brand() { Id = 4, BrandName = "Porsche", BrandCountry = "Germany", BrandYear = 1931 };

            Car Car1 = new Car() { Id = 1, CarName = "Suzuki Car1", CarType = "Swift", CarPrice = 1, NewOrUsed = "new", CarReleaseYear = 2000, CarColor = "black", CarSeatNumber = 4, IsLeftWheel = true, FuelType = "diesel", IsElectricCar = true, Brand_id = 1 };
            Car Car2 = new Car() { Id = 2, CarName = "Suzuki Car2", CarType = "Ignis", CarPrice = 3, NewOrUsed = "new",CarReleaseYear = 2005, CarColor = "white", CarSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricCar = true, Brand_id = 1 };
            Car Car3 = new Car() { Id = 3, CarName = "Suzuki Car3", CarType = "Swift", CarPrice = 15, NewOrUsed = "used",CarReleaseYear = 2020, CarColor = "red", CarSeatNumber = 6, IsLeftWheel = false, FuelType = "gasoline", IsElectricCar = false, Brand_id = 1 };
            Car Car4 = new Car() { Id = 4, CarName = "Suzuki Car4", CarType = "Vitara", CarPrice = 1, NewOrUsed = "used",CarReleaseYear = 1990, CarColor = "green", CarSeatNumber = 4, IsLeftWheel = false, FuelType = "diesel", IsElectricCar = false, Brand_id = 1 };
            Car Car5 = new Car() { Id = 5, CarName = "Toyota Car1", CarType = "Yaris", CarPrice = 4, NewOrUsed = "new", CarReleaseYear = 2020, CarColor = "red", CarSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricCar = true, Brand_id = 2 };
            Car Car6 = new Car() { Id = 6, CarName = "Toyota Car2", CarType = "Corolla", CarPrice = 1, NewOrUsed = "used", CarReleaseYear = 2000, CarColor = "green", CarSeatNumber = 3, IsLeftWheel = true, FuelType = "diesel", IsElectricCar = false, Brand_id = 2 };
            Car Car7 = new Car() { Id = 7, CarName = "Toyota Car3", CarType = "Yaris", CarPrice = 2, NewOrUsed = "new", CarReleaseYear = 2010, CarColor = "white", CarSeatNumber = 4, IsLeftWheel = true, FuelType = "diesel", IsElectricCar = false, Brand_id = 2 };
            Car Car8 = new Car() { Id = 8, CarName = "Toyota Car4", CarType = "Sienna", CarPrice = 10, NewOrUsed = "new", CarReleaseYear = 2017, CarColor = "black", CarSeatNumber = 4, IsLeftWheel = true, FuelType = "gasoline", IsElectricCar = true, Brand_id = 2 };
            Car Car9 = new Car() { Id = 9, CarName = "Ferrari Car1", CarType = "Ferrari 488", CarPrice = 10, NewOrUsed = "new", CarReleaseYear = 2011, CarColor = "black", CarSeatNumber = 6, IsLeftWheel = true, FuelType = "gasoline", IsElectricCar = true, Brand_id = 3 };
            Car Car10 = new Car() { Id = 10, CarName = "Ferrari Car2", CarType = "Ferrari 488", CarPrice = 15, NewOrUsed = "used", CarReleaseYear = 2018, CarColor = "red", CarSeatNumber = 4, IsLeftWheel = true, FuelType = "diesel", IsElectricCar = false, Brand_id = 3 };
            Car Car11 = new Car() { Id = 11, CarName = "Ferrari Car3", CarType = "Ferrari 458 Italia", CarPrice = 20, NewOrUsed = "new", CarReleaseYear = 2015, CarColor = "white", CarSeatNumber = 4, IsLeftWheel = true, FuelType = "gasoline", IsElectricCar = false, Brand_id = 3 };
            Car Car12 = new Car() { Id = 12, CarName = "Ferrari Car4", CarType = "Ferrari Portofino", CarPrice = 22, NewOrUsed = "new", CarReleaseYear = 2020, CarColor = "black", CarSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricCar = true, Brand_id = 3 };
            Car Car13 = new Car() { Id = 13, CarName = "Porsche Car1", CarType = "Porsche 911", CarPrice = 10, NewOrUsed = "new", CarReleaseYear = 2017, CarColor = "black", CarSeatNumber = 4, IsLeftWheel = true, FuelType = "gasoline", IsElectricCar = true, Brand_id = 4 };
            Car Car14 = new Car() { Id = 14, CarName = "Porsche Car2", CarType = "Porsche 968 Turbo S", CarPrice = 100, NewOrUsed = "new", CarReleaseYear = 2016, CarColor = "white", CarSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricCar = true, Brand_id = 4 };
            Car Car15 = new Car() { Id = 15, CarName = "Porsche Car3", CarType = "Porsche 999", CarPrice = 40, NewOrUsed = "used", CarReleaseYear = 2005, CarColor = "black", CarSeatNumber = 6, IsLeftWheel = true, FuelType = "diesel", IsElectricCar = false, Brand_id = 4 };
            Car Car16 = new Car() { Id = 16, CarName = "Porsche Car4", CarType = "Porsche 999", CarPrice = 35, NewOrUsed = "new", CarReleaseYear = 2019, CarColor = "red", CarSeatNumber = 4, IsLeftWheel = true, FuelType = "gasoline", IsElectricCar = true, Brand_id = 4 };

            RentCar RentCar1 = new RentCar() { Id = 1, BuyerName = "Sanya", BuyDate = 2020, BuyerGender = "male", IsFirstCar= false, Car_id = 1 };
            RentCar RentCar2 = new RentCar() { Id = 2, BuyerName = "Erik", BuyDate = 2022, BuyerGender = "male", IsFirstCar = true, Car_id = 8 };
            RentCar RentCar3 = new RentCar() { Id = 3, BuyerName = "Evelin", BuyDate = 2022, BuyerGender = "female", IsFirstCar = true, Car_id = 14 };
            RentCar RentCar4 = new RentCar() { Id = 4, BuyerName = "Erzsi", BuyDate = 2018, BuyerGender = "female", IsFirstCar = false, Car_id = 4 };


            modelBuilder.Entity<Brand>().HasData(Brand1, Brand2, Brand3, Brand4);
            modelBuilder.Entity<Car>().HasData(Car1, Car2, Car3, Car4, Car6, Car7, Car8, Car9, Car10, Car11, Car12, Car13, Car14, Car15, Car16);
            modelBuilder.Entity<RentCar>().HasData(RentCar1, RentCar2, RentCar3, RentCar4);

        }
    }
}
