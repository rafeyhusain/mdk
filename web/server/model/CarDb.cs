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
        public string GetCars(SerachFilters f)
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
            
            return JsonConvert.SerializeObject(list, Formatting.Indented);
        }

        //public Page<Car> GetFilteredEmployees(int pageSize, int currentPage, string searchText, int sortBy, string jobTitle)
        //{
        //    Page<Employee> employees;
        //    var filters = new Filters<Employee>();
        //    var sorts = new Sorts<Employee>();

        //    filters.Add(!string.IsNullOrEmpty(searchText), x => x.LoginID.Contains(searchText));
        //    filters.Add(!string.IsNullOrEmpty(jobTitle), x => x.JobTitle.Equals(jobTitle));

        //    sorts.Add(sortBy == 1, x => x.BusinessEntityID);
        //    sorts.Add(sortBy == 2, x => x.LoginID);
        //    sorts.Add(sortBy == 3, x => x.JobTitle);

        //    using (var context = new AdventureWorksEntities())
        //    {
        //        employees = context.Employees.Paginate(currentPage, pageSize, sorts, filters);
        //    }

        //    return employees;
        //}
    }
}
