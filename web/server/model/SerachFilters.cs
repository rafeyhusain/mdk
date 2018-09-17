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
    public enum SortBy
    {
        PriceLowest = 1,
        PriceHighest = 2,
        MileageLowest = 3,
        MileageHighest = 4 
    }

    public class SerachFilters
    {
        public SerachFilters()
        {

        }

        //public string Caption { get; set; }
        //public List<int> Price { get; set; }
        //public List<int> Rating { get; set; }
        //public string Make { get; set; }
        //public string Model { get; set; }
        //public List<int> Year { get; set; }
        //public List<int> Month { get; set; }
        //public List<int> Mileage { get; set; }
        //public string Condition { get; set; }
        //public string ExteriorColor { get; set; }
        //public string InteriorColor { get; set; }
        //public string Transmission { get; set; }
        //public string Engine { get; set; }
        //public string DriveTrain { get; set; }
        //public string Location { get; set; }
        //public string StockId { get; set; }
        //public string ChassisNo { get; set; }
        //public List<int> Displacement { get; set; }
        //public string Steering { get; set; }
        //public string FuelType { get; set; }
        //public string Door { get; set; }
        //public string Grade { get; set; }

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public int SortBy { get; set; }
    }
}
