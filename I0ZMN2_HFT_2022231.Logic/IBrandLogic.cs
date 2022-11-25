using I0ZMN2_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I0ZMN2_HFT_2022231.Logic
{
    public interface IBrandLogic
    {
        Brand GetBrandById(int id);
        IEnumerable<Brand> GetAllBrand();
        void AddNewBrand(Brand brand);
        void UpdateBrand(Brand brand);
        void DeleteBrand(int id);
    }
}
