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
    public class CarDetail
    {
        [Key, ForeignKey("Car")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarDetailId { get; set; }
        
        [Column(TypeName = "ntext")]
        public string Images { get; set; }

        [Column(TypeName = "ntext")]
        public string GeneralInformation { get; set; }

        [Column(TypeName = "ntext")]
        public string VechileOverview { get; set; }

        [Column(TypeName = "ntext")]
        public string Options { get; set; }

        [Column(TypeName = "ntext")]
        public string Features { get; set; }

        public Car Car { get; set; }
    }
}
