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
        Mock<ICarRepository> MockCarRepo = new Mock<ICarRepository>();
        Mock<IBrandRepository> MockBrandRepo = new Mock<IBrandRepository>();
        Mock<IRentCarRepository> MockRentCarRepo = new Mock<IRentCarRepository>();

        Carlogic CarLogic;
        BrandLogic BrandLogic;
        RentCarLogic RentCarLogic;

        //public int Id { get; set; }
        //public string CarName { get; set; }
        //public string CarType { get; set; }
        //public int CarPrice { get; set; }
        //public string NewOrUsed { get; set; }
        //public int CarReleaseYear { get; set; }
        //public string CarColor { get; set; }
        //public int CarSeatNumber { get; set; }
        //public bool IsLeftWheel { get; set; }
        //public string FuelType { get; set; }
        //public bool IsElectricCar { get; set; }

        static Car car = new Car()
        {
            Id = 1,
            CarName = "Carname",
            CarType = "Toyota",
            CarPrice = 3,
            NewOrUsed = "new",
            CarReleaseYear = 1992,
            CarColor = "red",
            CarSeatNumber = 3,
            IsLeftWheel = true,
            FuelType = "diesel",
            IsElectricCar = false,
            BrandId=1,
            CarBrand=brand,
            CarRents=(ICollection<RentCar>) rentcar
        };

        static Brand brand = new Brand()
        {
            Id = 1,
            BrandName = "Toyota",
            BrandCountry = "Japan",
            BrandYear = 1992,
            Cars = (ICollection<Car>) car
        };

        static RentCar rentcar = new RentCar()
        {
            RentId = 1,
            BuyerName = "Evelin",
            BuyDate = 2020,
            BuyerGender = "female",
            IsFirstCar = true,
            CarId = 1,
            Car = car,
        };

        

        public Tester()
        {
            BrandLogic = new BrandLogic(MockBrandRepo.Object);
            CarLogic = new Carlogic(MockCarRepo.Object, MockBrandRepo.Object);
            RentCarLogic = new RentCarLogic(MockRentCarRepo.Object);

            MockBrandRepo.Setup(r => r.Create(It.IsAny<Brand>()));
            MockCarRepo.Setup(r => r.Create(It.IsAny<Car>()));
            MockRentCarRepo.Setup(r => r.Create(It.IsAny<RentCar>()));

            MockBrandRepo.Setup(r => r.GetAll()).Returns(new List<Brand> { brand }.AsQueryable());
            MockCarRepo.Setup(r => r.GetAll()).Returns(new List<Car> { car }.AsQueryable());
            MockRentCarRepo.Setup(r => r.GetAll()).Returns(new List<RentCar> { rentcar }.AsQueryable());
        }

    }
}
