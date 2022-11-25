using System.Linq;

namespace I0ZMN2_HFT_2022231.Repository
{
    public interface IRepository<T> where T : class
    {
        void Create(T t);
        T Get(int id);
        IQueryable<T> GetAll();
        void Update(T t);
        void Delete(int id);
    }
}