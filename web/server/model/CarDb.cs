using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using EntityFrameworkPaginate;

namespace model
{
    public class CarDb
    {
        private static Dictionary<string, Object> options = null;

        public Page<Car> GetCars(CarFilter f)
        {
            Page<Car> list;
            var filters = new Filters<Car>();
            var sorts = new Sorts<Car>();

            filters.Add(f.Caption != null && f.Caption.Count > 0, car => f.Caption.Contains(car.Caption));
            filters.Add(f.Price != null && f.Price.Count == 2, car => car.Price >= f.Price[0] && car.Price <= f.Price[1]);
            filters.Add(f.Make != null && f.Make.Count > 0, car => f.Make.Contains(car.Make));
            filters.Add(f.Model != null && f.Model.Count > 0, car => f.Model.Contains(car.Model));
            filters.Add(f.Year != null && f.Year.Count == 2, car => car.Price >= f.Year[0] &&  car.Price <= f.Year[1]);
            filters.Add(f.Month != null && f.Month.Count > 0, car => f.Month.Contains(car.Month));
            filters.Add(f.Mileage != null && f.Mileage.Count == 2, car => car.Mileage >= f.Mileage[0] && car.Mileage <= f.Mileage[1]);
            filters.Add(f.Transmission != null && f.Transmission.Count > 0, car => f.Transmission.Contains(car.Transmission));
            filters.Add(f.Location != null && f.Location.Count > 0, car => f.Location.Contains(car.Location));
            filters.Add(f.StockId != null && f.StockId.Count > 0, car => f.StockId.Contains(car.StockId));
            filters.Add(f.ChassisNo != null && f.ChassisNo.Count > 0, car => f.ChassisNo.Contains(car.ChassisNo));
            filters.Add(f.Displacement != null && f.Displacement.Count == 2, car => car.Displacement >= f.Displacement[0] && car.Displacement <= f.Displacement[1]);
            filters.Add(f.Steering != null && f.Steering.Count > 0, car => f.Steering.Contains(car.Steering));
            filters.Add(f.FuelType != null && f.FuelType.Count > 0, car => f.FuelType.Contains(car.FuelType));
            filters.Add(f.Door != null && f.Door.Count > 0, car => f.Door.Contains(car.Door));
            filters.Add(f.Grade != null && f.Grade.Count > 0, car => f.Grade.Contains(car.Grade));
            filters.Add(f.Featured != null && f.Featured.Count > 0, car => f.Featured.Contains(car.Featured));

            sorts.Add(f.SortBy == (int)SortBy.PriceLowest, car => car.Price, false);
            sorts.Add(f.SortBy == (int)SortBy.PriceHighest, car => car.Price, true);
            sorts.Add(f.SortBy == (int)SortBy.MileageLowest, car => car.Mileage, false);
            sorts.Add(f.SortBy == (int)SortBy.MileageHighest, car => car.Mileage, true);

            using (var context = new CarDbContext())
            {
                list = context.Cars.Paginate(f.CurrentPage, f.PageSize, sorts, filters);
            }

            return list;
        }

        public Dictionary<string, Object> GetOptions()
        {
            if (CarDb.options != null)
            {
                return CarDb.options;
            }

            CarDb.options = new Dictionary<string, object>();

            using (var context = new CarDbContext())
            {
                CarDb.options.Add("Makes", context.Makes.ToList());
                CarDb.options.Add("Models", (from x in context.Models select new { Id = x.Id, Caption = x.Caption, MakeId = x.Make.Id }).ToList());
                CarDb.options.Add("Colors", context.Colors.ToList());
                CarDb.options.Add("FuelTypes", context.FuelTypes.ToList());
                CarDb.options.Add("Grades", context.Grades.ToList());
                CarDb.options.Add("Doors", context.Doors.ToList());
            }

            return options;
        }
    }
}
