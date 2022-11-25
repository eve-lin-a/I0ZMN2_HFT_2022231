using I0ZMN2_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I0ZMN2_HFT_2022231.Logic
{
    public interface IRentCarLogic
    {
        RentCar GetRentCarById(int id);
        IEnumerable<RentCar> GetAllBrand();
        void AddNewRentCar(RentCar rentcar);
        void UpdateRentCar(RentCar rentcar);
        void DeleteRentcar(int id);
    }
}
