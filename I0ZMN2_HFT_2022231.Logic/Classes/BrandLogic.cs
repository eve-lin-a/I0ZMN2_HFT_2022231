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
    public class BrandLogic : IBrandLogic
    {

        IRepository<Brand> brandRepo;
        IRepository<Car> carRepo;
        IRepository<RentCar> rentcarRepo;

        public BrandLogic(IRepository<Brand> brandRepo, IRepository<Car> carRepo, IRepository<RentCar> rentcarRepo)
        {
            this.brandRepo = brandRepo;
            this.carRepo = carRepo;
            this.rentcarRepo = rentcarRepo;
        }

        public void Create(Brand obj)
        {
            //if (obj.Name.Any(c => char.IsDigit(c)) || obj.City.Any(c => char.IsDigit(c)))
            //{
            //    throw new ArgumentException("Name and nationality can't contain numbers");
            //}
            //if (obj.Name == "" || obj.City == "")
            //{
            //    throw new ArgumentNullException("Can't be null");
            //}
            brandRepo.Create(obj);
        }

        public void Delete(int id)
        {
            brandRepo.Delete(id);
        }

        public Brand Read(int id)
        {
            //if (id < brandRepo.ReadAll().Count()+1)
            //    return brandRepo.Read(id);
            //else
            //    throw new IndexOutOfRangeException("Id is to big!");
            return brandRepo.Read(id);
        }

        public IQueryable<Brand> ReadAll()
        {
            return brandRepo.ReadAll();
        }

        public void Update(Brand obj)
        {
            brandRepo.Update(obj);
        }

        public IEnumerable<Brand> GetBrandWithSanya()
        {
            var q = from RentCars in rentcarRepo.ReadAll()
                    join Cars in carRepo.ReadAll()
                    on RentCars.Car_id equals Cars.Id
                    join Brands in brandRepo.ReadAll()
                    on Cars.Brand_id equals Brands.Id
                    where RentCars.BuyerName == "Sanya"
                    select Brands;
            return q;
        }

        public IEnumerable<Brand> GetBrandWhereGenderIsMale()
        {
            var q = from RentCars in rentcarRepo.ReadAll()
                    join Cars in carRepo.ReadAll()
                    on RentCars.Car_id equals Cars.Id
                    join Brands in brandRepo.ReadAll()
                    on Cars.Brand_id equals Brands.Id
                    where RentCars.BuyerGender == "male"
                    select Brands;
            return q;
        }
    }
}
