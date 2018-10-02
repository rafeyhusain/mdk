using EntityFrameworkPaginate;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Authorize = model.AuthorizeAttribute;

namespace api.Controllers
{
    public class CarController : ApiController
    {
        [HttpGet]
        [Route("api/cars/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var filters = new CarFilter();

            filters.CurrentPage = 1;
            filters.PageSize = 1;
            filters.SortBy = 1;

            var list = CarDb.GetCars(filters);

            return CarDb.CreateJsonResponse(list);
        }

        [HttpPost]
        [Route("api/cars/search")]
        public HttpResponseMessage Search(CarFilter filters)
        {
            if (filters == null)
            {
                filters = new CarFilter();

                filters.CurrentPage = 1;
                filters.PageSize = 10;
                filters.SortBy = 1;
            }

            var list = CarDb.GetCars(filters);

            return CarDb.CreateJsonResponse(list);
        }

        [HttpGet]
        [Route("api/options")]
        public HttpResponseMessage GetOptions()
        {
            var list = CarDb.GetOptions();

            return CarDb.CreateJsonResponse(list);
        }

        [HttpGet]
        [Route("api/options/reset")]
        public HttpResponseMessage ResetOptions()
        {
            var result = CarDb.ResetOptions();

            return CarDb.CreateJsonResponse(result);
        }
    }
}