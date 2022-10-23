using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I0ZMN2_HFT_2021222.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CarName { get; set; }
        public string CarType { get; set; }
        public int CarPrice { get; set; }
        public string NewOrUsed { get; set; }
        public int CarReleaseYear { get; set; }
        public string CarColor { get; set; }
        public int CarSeatNumber { get; set; }
        public bool IsLeftWheel { get; set; }
        public string FuelType { get; set; }
        public bool IsElectricCar { get; set; }
        [NotMapped]
        public virtual ICollection<RentCar> CarRents { get; set; }
        [NotMapped]
        public virtual Brand CarBrand { get; set; }
        [ForeignKey(nameof (Brand))]
        public int? BrandId { get; set; }

        public Car()
        {
            CarRents = new HashSet<RentCar>();
        }
    }
}
