using I0ZMN2_HFT_2022231.Models;

namespace I0ZMN2_HFT_2022231.Repository
{
    public interface IRentCarRepository : IRepository<RentCar>
    {
        void Create(RentCar t);
        void Delete(int id);
        RentCar Get(int id);
        void Update(RentCar t);
    }
}