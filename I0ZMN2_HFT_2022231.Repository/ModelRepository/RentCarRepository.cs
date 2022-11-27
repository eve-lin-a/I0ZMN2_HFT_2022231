using I0ZMN2_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I0ZMN2_HFT_2022231.Repository
{
    public class RentCarRepository : Repository<RentCar>
    {
        public RentCarRepository(CarDBContext hpctx) : base(hpctx)
        {
        }

        public override RentCar Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }
        public override void Update(RentCar obj)
        {
            var oldRentCar = Read(obj.Id);
            oldRentCar.Id = obj.Id;
            oldRentCar.BuyerName = obj.BuyerName;
            oldRentCar.BuyDate = obj.BuyDate;
            oldRentCar.BuyerGender = obj.BuyerGender;
            oldRentCar.IsFirstCar = obj.IsFirstCar;
            oldRentCar.Car_id = obj.Car_id;
            ctx.SaveChanges();
        }
        public override void Delete(int id)
        {
            ctx.Remove(Read(id));
            ctx.SaveChanges();
        }
    }
}
