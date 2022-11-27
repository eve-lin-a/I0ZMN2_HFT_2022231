using I0ZMN2_HFT_2022231.Logic;
using I0ZMN2_HFT_2022231.Models;
using I0ZMN2_HFT_2022231.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I0ZMN2_HFT_2022231.Test
{
    [TestFixture]
    public class Tester
    {
        RentCarLogic rentcarlogic;
        CarLogic carlogic;
        BrandLogic brandlogic;

        [SetUp]
        public void Setup()
        {
            Mock<IRepository<RentCar>> mockRentCarRepo = new Mock<IRepository<RentCar>>();
            Mock<IRepository<Car>> mockCarRepo = new Mock<IRepository<Car>>();
            Mock<IRepository<Brand>> mockBrandRepo = new Mock<IRepository<Brand>>();

            mockRentCarRepo.Setup(x => x.Read(It.IsAny<int>())).Returns(
                new RentCar()
                {
                    Id = 1,
                    BuyerName = "Tanya",
                    BuyDate = 2000,
                    BuyerGender = "female",
                    IsFirstCar = false,
                    Car_id = 1,
                });

            mockRentCarRepo.Setup(x => x.ReadAll()).Returns(FakeRentCarObject);
            mockCarRepo.Setup(x => x.ReadAll()).Returns(FakeCarObject);
            mockBrandRepo.Setup(x => x.ReadAll()).Returns(FakeBrandObject);

            rentcarlogic = new RentCarLogic(mockBrandRepo.Object, mockCarRepo.Object, mockRentCarRepo.Object);
            brandlogic = new BrandLogic(mockBrandRepo.Object, mockCarRepo.Object, mockRentCarRepo.Object);
            carlogic = new CarLogic(mockCarRepo.Object);

        }


        [Test]
        public void GetOneRentCarBuyerName()
        {
            Assert.That(rentcarlogic.Read(1).BuyerName, Is.EqualTo("Tanya"));
        }

        [Test]
        public void GetOneRentCarBuyDate()
        {
            Assert.That(rentcarlogic.Read(1).BuyDate, Is.EqualTo(2000));
        }

        [Test]
        public void GetOneRentCarBuyerGender()
        {
            Assert.That(rentcarlogic.Read(1).BuyerGender, Is.EqualTo("female"));
        }

        [Test]
        public void GetAllRentCar_ReturnsExactNumberOfInstances()
        {
            Assert.That(this.rentcarlogic.ReadAll().Count, Is.EqualTo(4));
        }

        [Test]
        public void GetRentCarAtTokyo_ReturnsCorrectInstance()
        {
            Assert.That(rentcarlogic.GetRentCarsAtSuzukiBrand().Count, Is.EqualTo(4));
        }


        [Test]
        public void GetRentCarWhereModelNameSuzuki1_ReturnsCorrectInstance()
        {
            Assert.That(rentcarlogic.GetRentCarsWhereCarModelNameIsSuzukiCar1().First().Car.IsElectricCar, Is.EqualTo(true));
        }

        [Test]
        public void GetRentCarWhereModelNameSuzuki2_ReturnsCorrectInstance()
        {
            Assert.That(rentcarlogic.GetRentCarsWhereCarModelNameIsSuzukiCar2().First().Car.IsElectricCar, Is.EqualTo(true));
        }

        [Test]
        public void GetBrandName()
        {
            Assert.That(brandlogic.GetBrandWithSanya().Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetOneRentCarIsFirstCar()
        {
            Assert.That(rentcarlogic.Read(1).IsFirstCar, Is.EqualTo(false));
        }

        [Test]
        public void GetOneRentCarCar_id()
        {
            Assert.That(rentcarlogic.Read(1).Car_id, Is.EqualTo(1));
        }


        private IQueryable<RentCar> FakeRentCarObject()
        {
            Brand Brand1 = new Brand() { Id = 1, BrandName = "Suzuki", BrandCountry = "Japan", BrandYear = 1909 };
            Brand Brand2 = new Brand() { Id = 2, BrandName = "Toyota", BrandCountry = "Japan", BrandYear = 1909 };
            Brand Brand3 = new Brand() { Id = 3, BrandName = "Ferrari", BrandCountry = "Italy", BrandYear = 1941 };


            Brand1.Cars = new List<Car>();
            Brand2.Cars = new List<Car>();
            Brand3.Cars = new List<Car>();

            // -------------------------------------------------------------------------------------------------------

            Car Car1 = new Car() { Id = 1, CarName = "Suzuki Car1", CarType = "Swift", CarPrice = 1, NewOrUsed = "new", CarReleaseYear = 2000, CarColor = "black", CarSeatNumber = 4, IsLeftWheel = true, FuelType = "diesel", IsElectricCar = true, Brand_id = 1 };
            Car Car2 = new Car() { Id = 2, CarName = "Suzuki Car2", CarType = "Ignis", CarPrice = 3, NewOrUsed = "new", CarReleaseYear = 2005, CarColor = "white", CarSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricCar = true, Brand_id = 1 };
            Car Car3 = new Car() { Id = 3, CarName = "Suzuki Car3", CarType = "Swift", CarPrice = 15, NewOrUsed = "used", CarReleaseYear = 2020, CarColor = "red", CarSeatNumber = 6, IsLeftWheel = false, FuelType = "gasoline", IsElectricCar = false, Brand_id = 1 };
            Car Car4 = new Car() { Id = 4, CarName = "Suzuki Car4", CarType = "Vitara", CarPrice = 1, NewOrUsed = "used", CarReleaseYear = 1990, CarColor = "green", CarSeatNumber = 4, IsLeftWheel = false, FuelType = "diesel", IsElectricCar = false, Brand_id = 1 };
            Car Car5 = new Car() { Id = 5, CarName = "Toyota Car1", CarType = "Yaris", CarPrice = 4, NewOrUsed = "new", CarReleaseYear = 2020, CarColor = "red", CarSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricCar = true, Brand_id = 2 };
            Car Car6 = new Car() { Id = 6, CarName = "Toyota Car2", CarType = "Corolla", CarPrice = 1, NewOrUsed = "used", CarReleaseYear = 2000, CarColor = "green", CarSeatNumber = 3, IsLeftWheel = true, FuelType = "diesel", IsElectricCar = false, Brand_id = 2 };


            Car1.Brand = Brand1;
            Car2.Brand = Brand1;
            Car3.Brand = Brand2;
            Car4.Brand = Brand2;
            Car5.Brand = Brand3;
            Car6.Brand = Brand3;

            Car1.Brand_id = Brand1.Id; Brand1.Cars.Add(Car1);
            Car2.Brand_id = Brand1.Id; Brand1.Cars.Add(Car2);
            Car3.Brand_id = Brand2.Id; Brand2.Cars.Add(Car3);
            Car4.Brand_id = Brand2.Id; Brand2.Cars.Add(Car4);
            Car5.Brand_id = Brand3.Id; Brand3.Cars.Add(Car5);
            Car6.Brand_id = Brand3.Id; Brand3.Cars.Add(Car6);

            Car1.RentCars = new List<RentCar>();
            Car2.RentCars = new List<RentCar>();
            Car3.RentCars = new List<RentCar>();
            Car4.RentCars = new List<RentCar>();
            Car5.RentCars = new List<RentCar>();
            Car6.RentCars = new List<RentCar>();

            // -------------------------------------------------------------------------------------------------------


            RentCar RentCar1 = new RentCar() { Id = 1, BuyerName = "Sanya", BuyDate = 2020, BuyerGender = "male", IsFirstCar = false, Car_id = 1 };
            RentCar RentCar2 = new RentCar() { Id = 2, BuyerName = "Erik", BuyDate = 2022, BuyerGender = "male", IsFirstCar = true, Car_id = 2 };
            RentCar RentCar3 = new RentCar() { Id = 3, BuyerName = "Evelin", BuyDate = 2022, BuyerGender = "female", IsFirstCar = true, Car_id = 3 };
            RentCar RentCar4 = new RentCar() { Id = 4, BuyerName = "Erzsi", BuyDate = 2018, BuyerGender = "female", IsFirstCar = false, Car_id = 4 };

            RentCar1.Car = Car1;
            RentCar2.Car = Car1;
            RentCar3.Car = Car2;
            RentCar4.Car = Car2;


            RentCar1.Car_id = Car1.Id; Car1.RentCars.Add(RentCar1);
            RentCar2.Car_id = Car1.Id; Car1.RentCars.Add(RentCar2);
            RentCar3.Car_id = Car2.Id; Car2.RentCars.Add(RentCar3);
            RentCar4.Car_id = Car2.Id; Car2.RentCars.Add(RentCar4);


            // -------------------------------------------------------------------------------------------------------

            List<RentCar> RentCar = new List<RentCar>();
            RentCar.Add(RentCar1);
            RentCar.Add(RentCar2);
            RentCar.Add(RentCar3);
            RentCar.Add(RentCar4);

            return RentCar.AsQueryable();
        }

        private IQueryable<Car> FakeCarObject()
        {
            Brand Brand1 = new Brand() { Id = 1, BrandName = "Suzuki", BrandCountry = "Japan", BrandYear = 1909 };
            Brand Brand2 = new Brand() { Id = 2, BrandName = "Toyota", BrandCountry = "Japan", BrandYear = 1909 };
            Brand Brand3 = new Brand() { Id = 3, BrandName = "Ferrari", BrandCountry = "Italy", BrandYear = 1941 };

            Brand1.Cars = new List<Car>();
            Brand2.Cars = new List<Car>();
            Brand3.Cars = new List<Car>();

            // -------------------------------------------------------------------------------------------------------

            Car Car1 = new Car() { Id = 1, CarName = "Suzuki Car1", CarType = "Swift", CarPrice = 1, NewOrUsed = "new", CarReleaseYear = 2000, CarColor = "black", CarSeatNumber = 4, IsLeftWheel = true, FuelType = "diesel", IsElectricCar = true, Brand_id = 1 };
            Car Car2 = new Car() { Id = 2, CarName = "Suzuki Car2", CarType = "Ignis", CarPrice = 3, NewOrUsed = "new", CarReleaseYear = 2005, CarColor = "white", CarSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricCar = true, Brand_id = 1 };
            Car Car3 = new Car() { Id = 3, CarName = "Suzuki Car3", CarType = "Swift", CarPrice = 15, NewOrUsed = "used", CarReleaseYear = 2020, CarColor = "red", CarSeatNumber = 6, IsLeftWheel = false, FuelType = "gasoline", IsElectricCar = false, Brand_id = 1 };
            Car Car4 = new Car() { Id = 4, CarName = "Suzuki Car4", CarType = "Vitara", CarPrice = 1, NewOrUsed = "used", CarReleaseYear = 1990, CarColor = "green", CarSeatNumber = 4, IsLeftWheel = false, FuelType = "diesel", IsElectricCar = false, Brand_id = 1 };
            Car Car5 = new Car() { Id = 5, CarName = "Toyota Car1", CarType = "Yaris", CarPrice = 4, NewOrUsed = "new", CarReleaseYear = 2020, CarColor = "red", CarSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricCar = true, Brand_id = 2 };
            Car Car6 = new Car() { Id = 6, CarName = "Toyota Car2", CarType = "Corolla", CarPrice = 1, NewOrUsed = "used", CarReleaseYear = 2000, CarColor = "green", CarSeatNumber = 3, IsLeftWheel = true, FuelType = "diesel", IsElectricCar = false, Brand_id = 2 };

            Car1.Brand = Brand1;
            Car2.Brand = Brand1;
            Car3.Brand = Brand2;
            Car4.Brand = Brand2;
            Car5.Brand = Brand3;
            Car6.Brand = Brand3;

            Car1.Brand_id = Brand1.Id; Brand1.Cars.Add(Car1);
            Car2.Brand_id = Brand1.Id; Brand1.Cars.Add(Car2);
            Car3.Brand_id = Brand2.Id; Brand2.Cars.Add(Car3);
            Car4.Brand_id = Brand2.Id; Brand2.Cars.Add(Car4);
            Car5.Brand_id = Brand3.Id; Brand3.Cars.Add(Car5);
            Car6.Brand_id = Brand3.Id; Brand3.Cars.Add(Car6);

            Car1.RentCars = new List<RentCar>();
            Car2.RentCars = new List<RentCar>();
            Car3.RentCars = new List<RentCar>();
            Car4.RentCars = new List<RentCar>();
            Car5.RentCars = new List<RentCar>();
            Car6.RentCars = new List<RentCar>();

            // -------------------------------------------------------------------------------------------------------

            RentCar RentCar1 = new RentCar() { Id = 1, BuyerName = "Sanya", BuyDate = 2020, BuyerGender = "male", IsFirstCar = false, Car_id = 1 };
            RentCar RentCar2 = new RentCar() { Id = 2, BuyerName = "Erik", BuyDate = 2022, BuyerGender = "male", IsFirstCar = true, Car_id = 2 };
            RentCar RentCar3 = new RentCar() { Id = 3, BuyerName = "Evelin", BuyDate = 2022, BuyerGender = "female", IsFirstCar = true, Car_id = 3 };
            RentCar RentCar4 = new RentCar() { Id = 4, BuyerName = "Erzsi", BuyDate = 2018, BuyerGender = "female", IsFirstCar = false, Car_id = 4 };

            RentCar1.Car = Car1;
            RentCar2.Car = Car1;
            RentCar3.Car = Car2;
            RentCar4.Car = Car2;


            RentCar1.Car_id = Car1.Id; Car1.RentCars.Add(RentCar1);
            RentCar2.Car_id = Car1.Id; Car1.RentCars.Add(RentCar2);
            RentCar3.Car_id = Car2.Id; Car2.RentCars.Add(RentCar3);
            RentCar4.Car_id = Car2.Id; Car2.RentCars.Add(RentCar4);
            // -------------------------------------------------------------------------------------------------------

            List<Car> Cars = new List<Car>();
            Cars.Add(Car1);
            Cars.Add(Car2);
            Cars.Add(Car3);
            Cars.Add(Car4);
            Cars.Add(Car5);
            Cars.Add(Car6);
            return Cars.AsQueryable();

        }
        private IQueryable<Brand> FakeBrandObject()
        {
            Brand Brand1 = new Brand() { Id = 1, BrandName = "Suzuki", BrandCountry = "Japan", BrandYear = 1909 };
            Brand Brand2 = new Brand() { Id = 2, BrandName = "Toyota", BrandCountry = "Japan", BrandYear = 1909 };
            Brand Brand3 = new Brand() { Id = 3, BrandName = "Ferrari", BrandCountry = "Italy", BrandYear = 1941 };


            Brand1.Cars = new List<Car>();
            Brand2.Cars = new List<Car>();
            Brand3.Cars = new List<Car>();

            // -------------------------------------------------------------------------------------------------------
            Car Car1 = new Car() { Id = 1, CarName = "Suzuki Car1", CarType = "Swift", CarPrice = 1, NewOrUsed = "new", CarReleaseYear = 2000, CarColor = "black", CarSeatNumber = 4, IsLeftWheel = true, FuelType = "diesel", IsElectricCar = true, Brand_id = 1 };
            Car Car2 = new Car() { Id = 2, CarName = "Suzuki Car2", CarType = "Ignis", CarPrice = 3, NewOrUsed = "new", CarReleaseYear = 2005, CarColor = "white", CarSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricCar = true, Brand_id = 1 };
            Car Car3 = new Car() { Id = 3, CarName = "Suzuki Car3", CarType = "Swift", CarPrice = 15, NewOrUsed = "used", CarReleaseYear = 2020, CarColor = "red", CarSeatNumber = 6, IsLeftWheel = false, FuelType = "gasoline", IsElectricCar = false, Brand_id = 1 };
            Car Car4 = new Car() { Id = 4, CarName = "Suzuki Car4", CarType = "Vitara", CarPrice = 1, NewOrUsed = "used", CarReleaseYear = 1990, CarColor = "green", CarSeatNumber = 4, IsLeftWheel = false, FuelType = "diesel", IsElectricCar = false, Brand_id = 1 };
            Car Car5 = new Car() { Id = 5, CarName = "Toyota Car1", CarType = "Yaris", CarPrice = 4, NewOrUsed = "new", CarReleaseYear = 2020, CarColor = "red", CarSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricCar = true, Brand_id = 2 };
            Car Car6 = new Car() { Id = 6, CarName = "Toyota Car2", CarType = "Corolla", CarPrice = 1, NewOrUsed = "used", CarReleaseYear = 2000, CarColor = "green", CarSeatNumber = 3, IsLeftWheel = true, FuelType = "diesel", IsElectricCar = false, Brand_id = 2 };

            Car1.Brand = Brand1;
            Car2.Brand = Brand1;
            Car3.Brand = Brand2;
            Car4.Brand = Brand2;
            Car5.Brand = Brand3;
            Car6.Brand = Brand3;

            Car1.Brand_id = Brand1.Id; Brand1.Cars.Add(Car1);
            Car2.Brand_id = Brand1.Id; Brand1.Cars.Add(Car2);
            Car3.Brand_id = Brand2.Id; Brand2.Cars.Add(Car3);
            Car4.Brand_id = Brand2.Id; Brand2.Cars.Add(Car4);
            Car5.Brand_id = Brand3.Id; Brand3.Cars.Add(Car5);
            Car6.Brand_id = Brand3.Id; Brand3.Cars.Add(Car6);

            Car1.RentCars = new List<RentCar>();
            Car2.RentCars = new List<RentCar>();
            Car3.RentCars = new List<RentCar>();
            Car4.RentCars = new List<RentCar>();
            Car5.RentCars = new List<RentCar>();
            Car6.RentCars = new List<RentCar>();

            // -------------------------------------------------------------------------------------------------------

            RentCar RentCar1 = new RentCar() { Id = 1, BuyerName = "Sanya", BuyDate = 2020, BuyerGender = "male", IsFirstCar = false, Car_id = 1 };
            RentCar RentCar2 = new RentCar() { Id = 2, BuyerName = "Erik", BuyDate = 2022, BuyerGender = "male", IsFirstCar = true, Car_id = 2 };
            RentCar RentCar3 = new RentCar() { Id = 3, BuyerName = "Evelin", BuyDate = 2022, BuyerGender = "female", IsFirstCar = true, Car_id = 3 };
            RentCar RentCar4 = new RentCar() { Id = 4, BuyerName = "Erzsi", BuyDate = 2018, BuyerGender = "female", IsFirstCar = false, Car_id = 4 };

            RentCar1.Car = Car1;
            RentCar2.Car = Car1;
            RentCar3.Car = Car2;
            RentCar4.Car = Car2;


            RentCar1.Car_id = Car1.Id; Car1.RentCars.Add(RentCar1);
            RentCar2.Car_id = Car1.Id; Car1.RentCars.Add(RentCar2);
            RentCar3.Car_id = Car2.Id; Car2.RentCars.Add(RentCar3);
            RentCar4.Car_id = Car2.Id; Car2.RentCars.Add(RentCar4);


            List<Brand> Brands = new List<Brand>();
            Brands.Add(Brand1);
            Brands.Add(Brand2);
            Brands.Add(Brand3);
            return Brands.AsQueryable();

        }
    }
}
