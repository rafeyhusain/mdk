namespace model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<model.CarDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(model.CarDbContext context)
        {
            IList<Car> car = new List<Car>();

            for (int i = 0; i < 100; i++)
            {
                car.Add(new Car()
                {
                    Caption = "TOYOTA ALLEX",
                    Price = 2700 + i * 100,
                    PriceOriginal = 2800 + i * 100,
                    Rating = 4,
                    Make = "TOYOTA",
                    Model = "ALLEX",
                    Year = 2005 + i % 10,
                    Month = 12,
                    Mileage = 5000 + i * 1000,
                    Condition = "New",
                    ExteriorColor = "SILVER",
                    InteriorColor = "GREY",
                    Transmission = "AUTO",
                    Engine = "5.1 L",
                    DriveTrain = "FWD",
                    Location = "Japan",
                    StockId = "47650",
                    ChassisNo = "NZE121-5095276",
                    Displacement = 1000 + i * 10,
                    Steering = "RIGHT",
                    FuelType = "Petrol",
                    Door = "FOUR DOOR",
                    Grade = "A GRADE",
                    Image = "1.jpg"
                });

                car.Add(new Car()
                {
                    Caption = "TOYOTA COROLLA RUNX",
                    Price = 2500 + i * 100,
                    PriceOriginal = 2900 + i * 100,
                    Rating = 4,
                    Make = "TOYOTA",
                    Model = "COROLLA RUNX",
                    Year = 2002 + i % 10,
                    Month = 12,
                    Mileage = 25000 + i * 1000,
                    Condition = "New",
                    ExteriorColor = "BLUE",
                    InteriorColor = "GREY",
                    Transmission = "AUTO",
                    Engine = "5.1 L",
                    DriveTrain = "FWD",
                    Location = "Japan",
                    StockId = "47652",
                    ChassisNo = "NZE121-0383520",
                    Displacement = 1500 + i * 10,
                    Steering = "RIGHT",
                    FuelType = "Petrol",
                    Door = "FOUR DOOR",
                    Grade = "A GRADE",
                    Image = "2.jpg"
                });
            }

            context.Cars.AddRange(car);
            context.SaveChanges();
        }
    }
}
