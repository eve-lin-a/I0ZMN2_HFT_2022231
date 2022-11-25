using System;
using System.Collections.Generic;
using System.Linq;

namespace I0ZMN2_HFT_2022231.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected CarDBContext hpctx;

        public Repository(CarDBContext hpctx)
        {
            this.hpctx = hpctx;
        }

        public abstract void Create(T t);


        public abstract void Delete(int id);


        public abstract T Get(int id);


        public IQueryable<T> GetAll()
        {
            return hpctx.Set<T>();
        }

        public abstract void Update(T t);
    }
}