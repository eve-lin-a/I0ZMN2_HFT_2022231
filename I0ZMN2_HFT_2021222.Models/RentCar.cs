using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I0ZMN2_HFT_2021222.Models
{
    public class RentCar
    {
        public int RentId { get; set; }
        public string BuyerName { get; set; }
        public int BuyDate { get; set; }
        public string BuyerGender { get; set; }
        public bool IsFirstCar { get; set; }

    }
}
