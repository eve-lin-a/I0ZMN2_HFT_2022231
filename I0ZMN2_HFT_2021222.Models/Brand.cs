using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I0ZMN2_HFT_2021222.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandCountry { get; set; }
        public int BrandYear { get; set; }
        public virtual ICollection<Car> Cars { get; set; }



    }
}
