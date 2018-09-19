﻿using System;
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

        public static void Seed(CarDbContext context)
        {
            IList<Car> car = new List<Car>();

            for (int i = 0; i < 5000; i++)
            {
                var result = i % 2 == 0;

                car.Add(new Car()
                {
                    Caption = result ? "TOYOTA ALLEX - " + i : "TOYOTA COROLLA RUNX - " + i,
                    Price = 2700 + i * 100,
                    PriceOriginal = 2800 + i * 100,
                    Make = result ? 1 : 2,
                    Model = result ? 1 : 2,
                    Year = 2005 + i % 10,
                    Month = result ? 11 : 12,
                    Mileage = 5000 + i * 1000,
                    Color = result ? 1 : 2,
                    Transmission = result ? 1 : 2,
                    Location = result ? 1 : 2,
                    StockId = "47650" + i,
                    ChassisNo = "NZE121-5095276-" + i,
                    Displacement = 1000 + i * 10,
                    Steering = result ? 1 : 2,
                    FuelType = result ? 1 : 2,
                    Door = result ? 1 : 2,
                    Grade = result ? 1 : 2,
                    Featured = result ? true : false,
                    Features = result ? @"[""Security System"", ""Air conditioning"", ""Alloy Wheels""]" : @"[ ""Anti-Lock Brakes(ABS)"", ""Anti-Theft"", ""Anti-Starter""]",
                    Images = result ? @"[""1.jpg"",""1.1.jpg"",""1.2.jpg"",""1.3.jpg""]" : @"[""2.jpg"",""2.1.jpg"",""2.2.jpg"",""2.3.jpg"",""2.4.jpg""]",
                });
            }

            context.Cars.AddRange(car);
            context.SaveChanges();
        }

        public static string Lorem(int count)
        {
            var text = new StringBuilder("Lorem ipsum dolor sit amet, consectetur adipisicing elit. Libero numquam repellendus non voluptate. Harum blanditiis ullam deleniti.");
            var result = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                result.Append(text);
            }

            return result.ToString();
        }
    }
}



