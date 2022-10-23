using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I0ZMN2_HFT_2021222.Models
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string BrandCountry { get; set; }
        public int BrandYear { get; set; }
        [NotMapped]
        public virtual ICollection<Car> Cars { get; set; }

        public Brand()
        {
            Cars=new HashSet<Car>();
        }

    }
}
