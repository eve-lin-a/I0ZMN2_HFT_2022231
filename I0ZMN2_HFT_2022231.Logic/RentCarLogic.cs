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
    public class RentCarLogic : IRentCarLogic
    {

        IRepository<RentCar> RentCarRepository;

        public RentCarLogic(IRepository<RentCar> RentCarRepository)
        {
            this.RentCarRepository = RentCarRepository;
        }


        public void AddNewRentCar(RentCar rentcar)
        {
            RentCarRepository.Create(rentcar);
        }

        public void DeleteRentcar(int id)
        {
            RentCarRepository.Delete(id);
        }

        public IEnumerable<RentCar> GetAllRentcar()
        {
            return RentCarRepository.GetAll();
        }

        public RentCar GetRentCarById(int id)
        {
            if (RentCarRepository.GetAll().Any(x => x.RentId.Equals(id)))
            {
                return RentCarRepository.Get(id);
            }
            else
            {
                throw new IndexOutOfRangeException("{ERROR} ID was too big!");
            }
        }

        public void UpdateRentCar(RentCar rentcar)
        {
            RentCarRepository.Update(rentcar);
        }
    }
}
