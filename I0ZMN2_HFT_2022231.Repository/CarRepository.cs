using I0ZMN2_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace I0ZMN2_HFT_2022231.Repository
{
    public class CarRepository : Repository<Car>, /*IRepository<Car>,*/ ICarRepository
    {
        public CarRepository(CarDBContext hpctx) : base(hpctx)
        {
        }

        public override void Create(Car t)
        {
            hpctx.Cars.Add(t);
            hpctx.SaveChanges();
        }

        public override void Delete(int id)
        {
            var carDelete = Get(id);
            hpctx.Cars.Remove(carDelete);
            hpctx.SaveChanges();
        }

        public override Car Get(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id.Equals(id));
        }

        public override void Update(Car t)
        {
            var carupdate = Get(t.Id);
            carupdate.CarName = t.CarName;
            hpctx.SaveChanges();
        }
    }
}
