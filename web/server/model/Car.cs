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

        [Index]
        public int Make { get; set; }

        [Index]
        public int Model { get; set; }

        [Index]
        public int Year { get; set; }
        public int Month { get; set; }

        [Index]
        public int Mileage { get; set; }

        [Index]
        public int Color { get; set; }

        [Index]
        public int Transmission { get; set; }

        [Index]
        public int Location { get; set; }
        public string StockId { get; set; }
        public string ChassisNo { get; set; }

        [Index]
        public int Displacement { get; set; }
        public int Steering { get; set; }

        [Index]
        public int FuelType { get; set; }

        [Index]
        public int Door { get; set; }

        [Index]
        public int Grade { get; set; }
        
        [Index]
        public bool Featured { get; set; }

        [Column(TypeName = "ntext")]
        public string Features { get; set; }

        [Column(TypeName = "ntext")]
        public string Images { get; set; }
    }
}





