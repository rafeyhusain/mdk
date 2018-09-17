using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkPaginate;
using Microsoft.AspNetCore.Mvc;
using model;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        CarDb db = new CarDb();

        [HttpGet]
        public Page<Car> Get()
        {
            var filters = new SerachFilters();

            filters.CurrentPage = 1;
            filters.PageSize = 10;
            filters.SortBy = 1;

            return db.GetCars(filters);
        }

        [HttpPost]
        public Page<Car> Post(SerachFilters filters)
        {
            if (filters == null)
            {
                filters = new SerachFilters();

                filters.CurrentPage = 1;
                filters.PageSize = 10;
                filters.SortBy = 1;
            }

            return db.GetCars(filters);
        }
    }
}
