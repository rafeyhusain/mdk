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

    public class CarFilter
    {
        public CarFilter()
        {

        }

        public List<string> Caption { get; set; }
        public List<int> Price { get; set; }
        public List<int> Make { get; set; }
        public List<int> Model { get; set; }
        public List<int> Year { get; set; }
        public List<int> Month { get; set; }
        public List<int> Mileage { get; set; }
        public List<int> Color { get; set; }
        public List<int> Transmission { get; set; }
        public List<int> Location { get; set; }
        public List<string> StockId { get; set; }
        public List<string> ChassisNo { get; set; }
        public List<int> Displacement { get; set; }
        public List<int> Steering { get; set; }
        public List<int> FuelType { get; set; }
        public List<int> Door { get; set; }
        public List<int> Grade { get; set; }
        public List<bool> Featured { get; set; }

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int SortBy { get; set; }
    }
}
