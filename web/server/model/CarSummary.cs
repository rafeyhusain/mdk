using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace model
{
    public class CarSummary
    {
        public CarSummary()
        {

        }

        public int CarId { get; set; }
        public string Caption { get; set; }
        public int Price { get; set; }
        public int Rating { get; set; }
        public int Make { get; set; }
        public int Model { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Mileage { get; set; }
        public int Condition { get; set; }
        public int Color { get; set; }
        public int Transmission { get; set; }
        public int Engine { get; set; }
        public int DriveTrain { get; set; }
        public int Location { get; set; }
        public string StockId { get; set; }
        public string ChassisNo { get; set; }
        public int Displacement { get; set; }
        public int Steering { get; set; }
        public int FuelType { get; set; }
        public int Door { get; set; }
        public int Grade { get; set; }
        public bool Featured { get; set; }
        public string Image { get; set; }
        public string Summary { get; set; }
    }
}
