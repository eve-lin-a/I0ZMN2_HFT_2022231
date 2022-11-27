using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace I0ZMN2_HFT_2022231.Models
{
    public class RentCar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string BuyerName { get; set; }
        public int BuyDate { get; set; }
        public string BuyerGender { get; set; }
        public bool IsFirstCar { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Car Car { get; set; }
        [ForeignKey(nameof(Car))]
        public int? Car_id { get; set; }

    }
}
