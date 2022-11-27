using I0ZMN2_HFT_2022231.Models;
using I0ZMN2_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace I0ZMN2_HFT_2022231.Logic
{
    public class CarLogic: ICarLogic
    {
        IRepository<Car> CarRepo;

        //DP injection
        public CarLogic(IRepository<Car> CarRepo)
        {
            this.CarRepo = CarRepo;
        }

        public void Create(Car obj)
        {
            //if (obj.Model == "")
            //{
            //    throw new ArgumentNullException("Can't be null");
            //}
            //if (obj.Price < 0)
            //{
            //    throw new ArgumentException("Negative price is not allowed");
            //}
            CarRepo.Create(obj);
        }

        public void Delete(int id)
        {
            CarRepo.Delete(id);
        }

        public Car Read(int id)
        {
            //if (id < CarRepo.ReadAll().Count()+1)
            //    return CarRepo.Read(id);
            //else
            //    throw new IndexOutOfRangeException("Id is to big!");
            return CarRepo.Read(id);

        }

        public IQueryable<Car> ReadAll()
        {
            return CarRepo.ReadAll();
        }

        public void Update(Car obj)
        {
            CarRepo.Update(obj);
        }


    }
}
