using I0ZMN2_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace I0ZMN2_HFT_2022231.Repository
{
    public class CarRepository : Repository<Car>
    {
        public CarRepository(CarDBContext hpctx) : base(hpctx)
        {
        }
        public override Car Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }
        public override void Update(Car obj)
        {
            var oldCar = Read(obj.Id);
            oldCar.Id = obj.Id;
            oldCar.CarName = obj.CarName;
            oldCar.CarType = obj.CarType;
            oldCar.CarPrice = obj.CarPrice;
            oldCar.CarReleaseYear = obj.CarReleaseYear;
            oldCar.CarColor = obj.CarColor;
            oldCar.CarSeatNumber = obj.CarSeatNumber;
            oldCar.IsLeftWheel = obj.IsLeftWheel;
            oldCar.FuelType = obj.FuelType;
            oldCar.IsElectricCar = obj.IsElectricCar;
            oldCar.Brand_id = obj.Brand_id;
            ctx.SaveChanges();
        }
        public override void Delete(int id)
        {
            ctx.Remove(Read(id));
            ctx.SaveChanges();
        }
    }
}
