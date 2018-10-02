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
using System.Net.Http;

namespace model
{
    public partial class CarDb
    {
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
    }
}
