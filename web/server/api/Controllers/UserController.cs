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
    public class UserController : ApiController
    {
        [Route("api/user/register")]
        [HttpPost]
        [AllowAnonymous]
        public IdentityResult Register(Account account)
        {
            return CarDb.Register(account);
        }

        [HttpGet]
        [Route("api/user/claims")]
        public Account GetUserClaims()
        {
            return CarDb.GetUserClaims();
        }

        [HttpGet]
        [Route("api/user/roles")]
        [AllowAnonymous]
        public HttpResponseMessage GetRoles()
        {
            var list = CarDb.GetRoles();

            return CarDb.CreateJsonResponse(list);
        }
    }
}