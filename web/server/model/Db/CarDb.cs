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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Collections;

namespace model
{
    public class CarDb
    {
        public static Page<Car> GetCars(CarFilter f)
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

        public static Account GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity) System.Web.HttpContext.Current.User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            Account account = new Account()
            {
                UserName = identityClaims.FindFirst("Username").Value,
                Email = identityClaims.FindFirst("Email").Value,
                FirstName = identityClaims.FindFirst("FirstName").Value,
                LastName = identityClaims.FindFirst("LastName").Value,
                LoggedOn = identityClaims.FindFirst("LoggedOn").Value
            };
            return account;
        }

        public static IdentityResult Register(Account account)
        {
            var userStore = new UserStore<ApplicationUser>(new CarDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser() { UserName = account.UserName, Email = account.Email };
            user.FirstName = account.FirstName;
            user.LastName = account.LastName;
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 3
            };
            IdentityResult result = manager.Create(user, account.Password);
            manager.AddToRoles(user.Id, account.Roles);
            return result;
        }

        public static Dictionary<string, Object> GetOptions()
        {
            if (Cache.Options != null)
            {
                return Cache.Options;
            }

            Cache.Options = new Dictionary<string, object>();

            using (var context = new CarDbContext())
            {
                Cache.Options.Add("Makes", context.Makes.ToList());
                Cache.Options.Add("Models", (from x in context.Models select new { Id = x.Id, Caption = x.Caption, MakeId = x.Make.Id }).ToList());
                Cache.Options.Add("Colors", context.Colors.ToList());
                Cache.Options.Add("FuelTypes", context.FuelTypes.ToList());
                Cache.Options.Add("Grades", context.Grades.ToList());
                Cache.Options.Add("Doors", context.Doors.ToList());
            }

            return Cache.Options;
        }

        public static bool ResetOptions()
        {
            Cache.Options = null;

            return true;
        }

        public static IList GetRoles()
        {
            var roleStore = new RoleStore<IdentityRole>(new CarDbContext());
            var roleMngr = new RoleManager<IdentityRole>(roleStore);

            var list = roleMngr.Roles
                .Select(x => new { x.Id, x.Name })
                .ToList();

            return list;
        }
    }
}
