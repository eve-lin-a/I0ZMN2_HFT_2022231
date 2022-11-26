using I0ZMN2_HFT_2022231.Models;
using I0ZMN2_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I0ZMN2_HFT_2022231.Logic
{
    public class Statistics
    {
        public IBrandRepository BrandRepo { get; set; }
        public ICarRepository CarRepo { get; set; }
        public IRentCarRepository RentCarRepo { get; set; }

        public Statistics(IBrandRepository brandRepository, ICarRepository carRepository,IRentCarRepository rentCarRepository)
        {
            BrandRepo = brandRepository;
            CarRepo = carRepository;
            RentCarRepo = rentCarRepository;
        }

        //1

        public IList<Car> ListAllCarforOneBrand(int id)
        {
            var res = BrandRepo.Get(id);
            return res.Cars.ToList();
        }

        //2

        public IList<RentCar> ListAllCarRentsFromOneCar(int id)
        {
            var res = CarRepo.Get(id);
            return res.CarRents.ToList();
        }

        //3

        public Car GetMostExpensiveCar()
        {
            var cars = CarRepo.GetAll();
            Car car = new Car();
            int max = 0;
            foreach (var item in cars)
            {
                if (item.CarPrice>max)
                {
                    max = item.CarPrice;
                    car = item;
                }
            }
            return car;
        }

        //4

        public IList<Car> GetCarsByColor(string color)
        {
            List<Car> cars = new List<Car>();
            var repocars = CarRepo.GetAll();
            foreach (var item in repocars)
            {
                if (item.CarColor==color)
                {
                    cars.Add(item);
                }
            }
            return cars;
        }

        //5

        public IList<RentCar> GetFirstBuyers()
        {
            List<RentCar> firstbuyers = new List<RentCar>();
            var rents=RentCarRepo.GetAll();
            foreach (var item in rents)
            {
                if (item.IsFirstCar)
                {
                    firstbuyers.Add(item);
                }
            }
            return firstbuyers;
        }

    }
}
