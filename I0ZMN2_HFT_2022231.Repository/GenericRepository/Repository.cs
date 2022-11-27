using System;
using System.Collections.Generic;
using System.Linq;

namespace I0ZMN2_HFT_2022231.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected CarDBContext ctx;

        public Repository(CarDBContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(T obj)
        {
            ctx.Add(obj);
            ctx.SaveChanges();
        }


        public abstract T Read(int id);
        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }
        public abstract void Update(T obj);
        public abstract void Delete(int id);
    }
}