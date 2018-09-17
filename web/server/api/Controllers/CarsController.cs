using EntityFrameworkPaginate;
using model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class CarsController : ApiController
    {
        CarDb db = new CarDb();

        public static HttpResponseMessage CreateJsonResponse(object value)
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(value), System.Text.Encoding.UTF8, "application/json")
            };

        }

        [HttpGet]
        [Route("api/cars")]
        public HttpResponseMessage Get()
        {
            var filters = new SerachFilters();

            filters.CurrentPage = 1;
            filters.PageSize = 10;
            filters.SortBy = 1;

            var list = db.GetCars(filters);

            return CreateJsonResponse(list);
        }

        [HttpPost]
        [Route("api/cars/search")]
        public HttpResponseMessage Search(SerachFilters filters)
        {
            if (filters == null)
            {
                filters = new SerachFilters();

                filters.CurrentPage = 1;
                filters.PageSize = 10;
                filters.SortBy = 1;
            }

            var list = db.GetCars(filters);

            return CreateJsonResponse(list);
        }
    }
}