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
    public class CarsController : ApiController
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

            return CreateJsonResponse(list);
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

            return CreateJsonResponse(list);
        }

        [HttpGet]
        [Route("api/options")]
        public HttpResponseMessage GetOptions()
        {
            var list = CarDb.GetOptions();

            return CreateJsonResponse(list);
        }

        [HttpGet]
        [Route("api/options/reset")]
        public HttpResponseMessage ResetOptions()
        {
            var result = CarDb.ResetOptions();

            return CreateJsonResponse(result);
        }

        [Route("api/User/Register")]
        [HttpPost]
        [AllowAnonymous]
        public IdentityResult Register(Account account)
        {
            return CarDb.Register(account);
        }

        [HttpGet]
        [Route("api/GetUserClaims")]
        public Account GetUserClaims()
        {
            return CarDb.GetUserClaims();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("api/ForAdminRole")]
        public string ForAdminRole()
        {
            return "for admin role";
        }

        [HttpGet]
        [Authorize(Roles = "Author")]
        [Route("api/ForAuthorRole")]
        public string ForAuthorRole()
        {
            return "For author role";
        }

        [HttpGet]
        [Authorize(Roles = "Author,Reader")]
        [Route("api/ForAuthorOrReader")]
        public string ForAuthorOrReader()
        {
            return "For author/reader role";
        }

        [HttpGet]
        [Route("api/user/roles")]
        [AllowAnonymous]
        public HttpResponseMessage GetRoles()
        {
            var list = CarDb.GetRoles();

            return CreateJsonResponse(list);
        }

        public static HttpResponseMessage CreateJsonResponse(object value)
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(value), System.Text.Encoding.UTF8, "application/json")
            };
        }
    }
}