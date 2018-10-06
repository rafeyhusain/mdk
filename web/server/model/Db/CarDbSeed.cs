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
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace model
{
    public class CarDbSeed
    {
        public static void Seed(CarDbContext context)
        {
            AddCars(context);
            AddMake(context);
            AddModel(context);
            AddFuelType(context);
            AddColor(context);
            AddGrade(context);
            AddDoor(context);
            AddRole(context);
            AddUser(context);
        }

        private static void AddCars(CarDbContext context)
        {
            IList<Car> list = new List<Car>();

            for (int i = 0; i < 5000; i++)
            {
                var result = i % 2 == 0;

                list.Add(new Car()
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

            context.Cars.AddRange(list);
            context.SaveChanges();
        }

        private static void AddMake(CarDbContext context)
        {
            IList<Make> list = new List<Make>();

            for (int i = 0; i < 2; i++)
            {
                var result = i % 2 == 0;

                list.Add(new Make()
                {
                    Caption = result ? "TOYOTA" : "HONDA",
                });
            }

            context.Makes.AddRange(list);
            context.SaveChanges();
        }

        private static void AddModel(CarDbContext context)
        {
            IList<Model> list = new List<Model>();

            for (int i = 0; i < 2; i++)
            {
                var result = i % 2 == 0;

                list.Add(new Model()
                {
                    Caption = result ? "ALLEX" : "AQUA",
                    Make = (from item in context.Makes
                         where item.Id == i + 1
                            select item).FirstOrDefault<Make>()
                });
            }

            context.Models.AddRange(list);
            context.SaveChanges();
        }

        private static void AddColor(CarDbContext context)
        {
            IList<Color> list = new List<Color>();

            for (int i = 0; i < 2; i++)
            {
                var result = i % 2 == 0;

                list.Add(new Color()
                {
                    Caption = result ? "Grey" : "Blue",
                });
            }

            context.Colors.AddRange(list);
            context.SaveChanges();
        }

        private static void AddFuelType(CarDbContext context)
        {
            IList<FuelType> list = new List<FuelType>();

            for (int i = 0; i < 2; i++)
            {
                var result = i % 2 == 0;

                list.Add(new FuelType()
                {
                    Caption = result ? "CNG + Petrol" : "Petrol",
                });
            }

            context.FuelTypes.AddRange(list);
            context.SaveChanges();
        }

        private static void AddGrade(CarDbContext context)
        {
            IList<Grade> list = new List<Grade>();

            for (int i = 0; i < 2; i++)
            {
                var result = i % 2 == 0;

                list.Add(new Grade()
                {
                    Caption = result ? "A Grade" : "B Grade",
                });
            }

            context.Grades.AddRange(list);
            context.SaveChanges();
        }

        private static void AddDoor(CarDbContext context)
        {
            IList<Door> list = new List<Door>();

            for (int i = 0; i < 2; i++)
            {
                var result = i % 2 == 0;

                list.Add(new Door()
                {
                    Caption = result ? "4 Door" : "5 Door",
                });
            }

            context.Doors.AddRange(list);
            context.SaveChanges();
        }

        private static void AddRole(CarDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleMngr = new RoleManager<IdentityRole>(roleStore);

            roleMngr.Create(new IdentityRole("Admin"));
            roleMngr.Create(new IdentityRole("User"));
        }

        private static void AddUser(CarDbContext context)
        {
            CarDb.Signup(new Account
            {
                Email = "admin@mdkjapan.com",
                UserName = "admin",
                Password = "admin",
                FirstName = "Admin",
                LastName = "Admin",
                Roles = new string[] { "Admin" }
            });

            CarDb.Signup(new Account
            {
                Email = "user@mdkjapan.com",
                UserName = "user",
                Password = "user",
                FirstName = "User",
                LastName = "User",
                Roles = new string[] { "User" }
            });
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



