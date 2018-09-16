using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using model;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        CarDb db = new CarDb();

        // GET api/values
        [HttpGet]
        public string Get()
        //public string Get([FromBody] SerachFilters filters)
        {
            var filters = new SerachFilters();

            filters.CurrentPage = 1;
            filters.PageSize = 5;
            filters.Price = new List<int>(new [] {2800, 3500});
            filters.SortBy = 1;

            return db.GetCars(filters);
        }
    }
}
