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
        //CRUD
        void Create(RentCar obj);
        RentCar Read(int id);
        IQueryable<RentCar> ReadAll();
        void Update(RentCar obj);
        void Delete(int id);

        //non-CRUD
        IEnumerable<RentCar> GetRentCarsAtSuzukiBrand();
        IEnumerable<RentCar> GetRentCarWhereCarPriceIsOver4();
        IEnumerable<RentCar> GetRentCarsWhereCarModelNameIsSuzukiCar1();
        IEnumerable<RentCar> GetRentCarsWhereCarModelNameIsSuzukiCar2();
    }
}
