using I0ZMN2_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I0ZMN2_HFT_2022231.Repository
{
    public class RentCarRepository : Repository<RentCar>, IRepository<RentCar>
    {
        public RentCarRepository(CarDBContext hpctx) : base(hpctx)
        {
        }

        public override void Create(RentCar t)
        {
            hpctx.Rents.Add(t);
            hpctx.SaveChanges();
        }

        public override void Delete(int id)
        {
            var rentcarDelete = Get(id);
            hpctx.Rents.Remove(rentcarDelete);
            hpctx.SaveChanges();
        }

        public override RentCar Get(int id)
        {
            return GetAll().SingleOrDefault(x => x.RentId.Equals(id));
        }

        public override void Update(RentCar t)
        {
            var rentcarupdate = Get(t.RentId);
            rentcarupdate.BuyerName = t.BuyerName;
            hpctx.SaveChanges();
        }
    }
}
