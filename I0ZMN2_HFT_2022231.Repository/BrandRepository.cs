using I0ZMN2_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I0ZMN2_HFT_2022231.Repository
{
    public class BrandRepository : Repository<Brand>, IRepository<Brand>
    {
        public BrandRepository(CarDBContext hpctx) : base(hpctx)
        {
        }

        public override void Create(Brand t)
        {
            hpctx.Brands.Add(t);
            hpctx.SaveChanges();
        }

        public override void Delete(int id)
        {
            var brandDelete = Get(id);
            hpctx.Brands.Remove(brandDelete);
            hpctx.SaveChanges();
        }

        public override Brand Get(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id.Equals(id));
        }

        public override void Update(Brand t)
        {
            var carupdate = Get(t.Id);
            carupdate.BrandName = t.BrandName;
            hpctx.SaveChanges();
        }
    }
}
