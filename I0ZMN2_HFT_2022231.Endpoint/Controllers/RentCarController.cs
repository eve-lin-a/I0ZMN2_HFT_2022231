using I0ZMN2_HFT_2022231.Logic;
using I0ZMN2_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace I0ZMN2_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RentCarController : ControllerBase
    {
        IRentCarLogic rentcarlogic;

        public RentCarController(IRentCarLogic rentcarlogic)
        {
            this.rentcarlogic = rentcarlogic;
        }

        // GET: RentCar
        [HttpGet]
        public IEnumerable<RentCar> Get()
        {
            return rentcarlogic.ReadAll();
        }

        // GET RentCar/5
        [HttpGet("{id}")]
        public RentCar Get(int id)
        {
            return rentcarlogic.Read(id);
        }

        // POST RentCar
        [HttpPost]
        public void Post([FromBody] RentCar value)
        {
            rentcarlogic.Create(value);
        }

        // PUT RentCar/5
        [HttpPut]
        public void Put([FromBody] RentCar value)
        {
            rentcarlogic.Update(value);
        }

        // DELETE RentCar/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var RentCarToDelete = this.rentcarlogic.Read(id);
            rentcarlogic.Delete(id);
        }
    }
}
