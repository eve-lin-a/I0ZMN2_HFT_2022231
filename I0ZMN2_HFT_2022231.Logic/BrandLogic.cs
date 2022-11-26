using I0ZMN2_HFT_2022231.Models;
using I0ZMN2_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace I0ZMN2_HFT_2022231.Logic
{
    public class BrandLogic : IBrandLogic
    {

        IRepository<Brand> BrandRepository;

        public BrandLogic(IRepository<Brand> BrandRepository)
        {
            this.BrandRepository = BrandRepository;
        }



        public void AddNewBrand(Brand brand)
        {
            BrandRepository.Create(brand);
        }

        public void DeleteBrand(int id)
        {
            BrandRepository.Delete(id);
        }

        public IEnumerable<Brand> GetAllBrand()
        {
            return BrandRepository.GetAll();
        }

        public Brand GetBrandById(int id)
        {
            if (BrandRepository.GetAll().Any(x => x.Id.Equals(id)))
            {
                return BrandRepository.Get(id);
            }
            else
            {
                throw new IndexOutOfRangeException("{ERROR} ID was too big!");
            }
        }

        public void UpdateBrand(Brand brand)
        {
            BrandRepository.Update(brand);
        }
    }
}
