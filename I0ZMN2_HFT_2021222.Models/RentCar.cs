using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I0ZMN2_HFT_2021222.Models
{
    public class RentCar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentId { get; set; }
        public string BuyerName { get; set; }
        public int BuyDate { get; set; }
        public string BuyerGender { get; set; }
        public bool IsFirstCar { get; set; }
        [NotMapped]
        public virtual Car Car { get; set; }
        [ForeignKey(nameof(Car))]
        public int? CarId { get; set; }

    }
}
