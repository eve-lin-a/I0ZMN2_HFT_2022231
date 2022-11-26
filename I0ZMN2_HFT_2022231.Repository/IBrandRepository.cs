using I0ZMN2_HFT_2022231.Models;

namespace I0ZMN2_HFT_2022231.Repository
{
    public interface IBrandRepository : IRepository<Brand>
    {
        void Create(Brand t);
        void Delete(int id);
        Brand Get(int id);
        void Update(Brand t);
    }
}