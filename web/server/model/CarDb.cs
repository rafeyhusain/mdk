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
        public Page<Car> GetCars(SerachFilters f)
        {
            Page<Car> list;
            var filters = new Filters<Car>();
            var sorts = new Sorts<Car>();

            //filters.Add(1 == 1, x => x.Price >= f.Price[0] && x.Price <= f.Price[1]);

            sorts.Add(f.SortBy == (int)SortBy.PriceLowest, x => x.Price, false);
            sorts.Add(f.SortBy == (int)SortBy.PriceHighest, x => x.Price, true);
            sorts.Add(f.SortBy == (int)SortBy.MileageLowest, x => x.Mileage, false);
            sorts.Add(f.SortBy == (int)SortBy.MileageHighest, x => x.Mileage, true);

            using (var context = new CarDbContext())
            {
                list = context.Cars.Paginate(f.CurrentPage, f.PageSize, sorts, filters);
            }
            
            return list;
        }
    }
}
