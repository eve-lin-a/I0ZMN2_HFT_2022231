using I0ZMN2_HFT_2022231.Models;
using I0ZMN2_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace I0ZMN2_HFT_2022231.Logic
{
    public class RentCarLogic : IRentCarLogic
    {

        IRepository<Brand> BrandRepo;
        IRepository<Car> CarRepo;
        IRepository<RentCar> RentCarRepo;
        public RentCarLogic(IRepository<Brand> BrandRepo, IRepository<Car> CarRepo, IRepository<RentCar> RentCarRepo)
        {
            this.BrandRepo = BrandRepo;
            this.CarRepo = CarRepo;
            this.RentCarRepo = RentCarRepo;
        }



        public void Create(RentCar obj)
        {
            //if (obj.Last_name ==""|| obj.Nationality =="")
            //{
            //    throw new ArgumentNullException("Can't be null");
            //}
            //if (obj.Last_name.Any(c =>char.IsDigit(c)) || obj.Nationality.Any(c => char.IsDigit(c)))
            //{
            //    throw new ArgumentException("Name and nationality can't contain numbers");
            //}
            RentCarRepo.Create(obj);
        }

        public void Delete(int id)
        {
            RentCarRepo.Delete(id);
        }

        public RentCar Read(int id)
        {
            //if (id < RentCarRepo.ReadAll().Count()+1)
            //    return RentCarRepo.Read(id);
            //else
            //    throw new IndexOutOfRangeException("Id is to big!");
            return RentCarRepo.Read(id);

        }

        public IQueryable<RentCar> ReadAll()
        {
            return RentCarRepo.ReadAll();
        }

        public void Update(RentCar obj)
        {
            RentCarRepo.Update(obj);
        }
        public IEnumerable<RentCar> GetRentCarsAtSuzukiBrand()
        {
            var q = from RentCars in RentCarRepo.ReadAll()
                    join Cars in CarRepo.ReadAll()
                    on RentCars.Car_id equals Cars.Id
                    join Brands in BrandRepo.ReadAll()
                    on Cars.Brand_id equals Brands.Id
                    where Brands.BrandName == "Suzuki"
                    select RentCars;

            return q;
        }
        public IEnumerable<RentCar> GetRentCarWhereCarPriceIsOver4()
        {
            var q = from RentCars in RentCarRepo.ReadAll()
                    join Cars in CarRepo.ReadAll()
                    on RentCars.Car_id equals Cars.Id
                    where Cars.CarPrice > 4
                    select RentCars;
            return q;
        }

        public IEnumerable<RentCar> GetRentCarsWhereCarModelNameIsSuzukiCar1()
        {
            var q = from RentCars in RentCarRepo.ReadAll()
                    join Cars in CarRepo.ReadAll()
                    on RentCars.Car_id equals Cars.Id
                    where Cars.CarName == "Suzuki Car1"
                    select RentCars;
            return q;
        }

        public IEnumerable<RentCar> GetRentCarsWhereCarModelNameIsSuzukiCar2()
        {
            var q = from RentCars in RentCarRepo.ReadAll()
                    join Cars in CarRepo.ReadAll()
                    on RentCars.Car_id equals Cars.Id
                    where Cars.CarName == "Suzuki Car2"
                    select RentCars;
            return q;
        }
    }
}
