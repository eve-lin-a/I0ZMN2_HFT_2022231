using I0ZMN2_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace I0ZMN2_HFT_2022231.Logic
{
    public interface ICarLogic
    {
        //CRUD
        void Create(Car obj);
        Car Read(int id);
        IQueryable<Car> ReadAll();
        void Update(Car obj);
        void Delete(int id);

        //non-CRUD

    }
}
