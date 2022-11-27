using I0ZMN2_HFT_2022231.Endpoint.Services;
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
    public class BrandController : ControllerBase
    {
        IBrandLogic logic;
        IHubContext<SignalRHub> hub;

        public BrandController(IBrandLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        // GET: api/<BrandController>
        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Brand value)
        {
            logic.Create(value);
            this.hub.Clients.All.SendAsync("BrandCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Brand value)
        {
            logic.Update(value);
            this.hub.Clients.All.SendAsync("BrandUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var BrandToDelete = this.logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("BrandDeleted", BrandToDelete);
            this.hub.Clients.All.SendAsync("CarDeleted", null);
            this.hub.Clients.All.SendAsync("RentCarDeleted", null);
        }
    }
}
