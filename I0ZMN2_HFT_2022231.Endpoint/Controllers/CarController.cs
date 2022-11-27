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
    public class CarController : ControllerBase
    {
        ICarLogic carlogic;

        public CarController(ICarLogic carlogic)
        {
            this.carlogic = carlogic;
        }

        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return carlogic.ReadAll();
        }

        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return carlogic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Car value)
        {
            carlogic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Car value)
        {
            carlogic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var CarToDelete = this.carlogic.Read(id);
            carlogic.Delete(id);

        }
    }
}
