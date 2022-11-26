using I0ZMN2_HFT_2022231.Models;

namespace I0ZMN2_HFT_2022231.Repository
{
    public interface ICarRepository:IRepository<Car>
    {
        void Create(Car t);
        void Delete(int id);
        Car Get(int id);
        void Update(Car t);
    }
}