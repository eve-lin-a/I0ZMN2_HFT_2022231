﻿using I0ZMN2_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I0ZMN2_HFT_2022231.Logic
{
    public interface IBrandLogic
    {
        //CRUD
        void Create(Brand obj);
        Brand Read(int id);
        IQueryable<Brand> ReadAll();
        void Update(Brand obj);
        void Delete(int id);

        //non-CRUD
        IEnumerable<Brand> GetBrandWithSanya();
        IEnumerable<Brand> GetBrandWhereGenderIsMale();
    }
}
