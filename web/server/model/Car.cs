using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace model
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarId { get; set; }
        public string Caption { get; set; }

        [Index]
        public int Price { get; set; }
        public int PriceOriginal { get; set; }
        public int Rating { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        [Index]
        public int Year { get; set; }
        public int Month { get; set; }

        [Index]
        public int Mileage { get; set; }
        public string Condition { get; set; }
        public string ExteriorColor { get; set; }
        public string InteriorColor { get; set; }
        public string Transmission { get; set; }
        public string Engine { get; set; }
        public string DriveTrain { get; set; }
        public string Location { get; set; }
        public string StockId { get; set; }
        public string ChassisNo { get; set; }
        public int Displacement { get; set; }
        public string Steering { get; set; }
        public string FuelType { get; set; }
        public string Door { get; set; }
        public string Grade { get; set; }
        public string Image { get; set; }

        public CarDetail CarDetail { get; set; }
    }
}
