using I0ZMN2_HFT_2022231.Logic;
using I0ZMN2_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace I0ZMN2_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IRentCarLogic rentcarlogic;
        IBrandLogic brandlogic;

        public StatController(IRentCarLogic rentcarlogic, IBrandLogic brandlogic)
        {
            this.rentcarlogic = rentcarlogic;
            this.brandlogic = brandlogic;
        }

        [HttpGet]
        public IEnumerable<RentCar> GetRentCarsAtSuzukiBrand()
        {
            return rentcarlogic.GetRentCarsAtSuzukiBrand();
        }
        [HttpGet]
        public IEnumerable<RentCar> GetRentCarWhereCarPriceIsOver4() 
        {
            return rentcarlogic.GetRentCarWhereCarPriceIsOver4();
        }
        [HttpGet]
        public IEnumerable<RentCar> GetRentCarsWhereCarModelNameIsSuzuki1()
        {
            return rentcarlogic.GetRentCarsWhereCarModelNameIsSuzukiCar1();
        }

        [HttpGet]
        public IEnumerable<Brand> GetBrandWithSanya()
        {
            return brandlogic.GetBrandWithSanya();
        }
        [HttpGet]
        public IEnumerable<Brand> GetBrandWhereGenderIsMale()
        {
            return brandlogic.GetBrandWhereGenderIsMale();
        }
    }
}
