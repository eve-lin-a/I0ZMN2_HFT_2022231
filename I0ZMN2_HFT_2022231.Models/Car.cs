using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace I0ZMN2_HFT_2022231.Models
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
        [JsonIgnore]
        public virtual ICollection<RentCar> RentCars { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Brand Brand { get; set; }
        [ForeignKey(nameof (Brand))]
        public int? Brand_id { get; set; }

        public Car()
        {
            RentCars = new HashSet<RentCar>();
        }

    }
}
